using System.Collections.Generic;
using System;
using Entitas;
using Lockstep.ECS;
using Lockstep.Math;
using Debug = Lockstep.Logging.Debug;

namespace Lockstep.Game {
    
    [System.Serializable]
    public partial class GameUnitService : GameService, IGameUnitService {
        private ActorContext _actorContext;
        private GameContext _gameContext;

        public const ushort CampStartId = 1001;
        public const ushort BulletStartId = 2001;
        public const ushort EffectStartId = 3001;
        public const ushort ItemStartId = 4001;
        public const ushort PlayerStartId = 5001;
        public const ushort EnemyStartId = 6001;

        public override void DoAwake(IServiceContainer services){
            var contexts = services.GetService<IConstStateService>().Contexts as Contexts;
            _actorContext = contexts.actor;
            _gameContext = contexts.game;
        }


        public void TakeDamage(IEntity pbullet, IEntity psuffer){
            var bullet = pbullet as GameEntity;
            var suffer = psuffer as GameEntity;
            if (suffer.isDestroyed) return;
            if (suffer.unit.health <= bullet.unit.damage) {
                bullet.unit.health -= suffer.unit.health;
                suffer.unit.health = 0;
                suffer.unit.killerLocalId = bullet.bullet.ownerLocalId;
                suffer.isDestroyed = true;
            }
            else {
                suffer.unit.health -= bullet.unit.damage;
                bullet.unit.health = 0;
                bullet.isDestroyed = true;
            }
        }

        public void DropItem(LFloat rate){
            if (_randomService.value >= rate) {
                return;
            }

            var min = _gameConstStateService.mapMin;
            var max = _gameConstStateService.mapMax;
            var x = _randomService.Range(min.x + 4, max.x - 4);
            var y = _randomService.Range(min.y + 4, max.y - 4);
            var detailType = _randomService.Range(0, (int)EItemType.EnumCount);
            CreateItem(new LVector2(x, y), (ushort) (detailType + ItemStartId));
        }


        private void CreateItem(LVector2 createPos, ushort type){
            CreateUnit(createPos, EntityUtil.CreateEntityItem(_gameContext, type), EDir.Up);
        }

        public void CreateCamp(LVector2 createPos, ushort type){
            CreateUnit(createPos + _gameConfigService.TankBornOffset,
                EntityUtil.CreateEntityCamp(_gameContext, type), EDir.Up);
        }

        public void CreateBullet(LVector2 pos, EDir dir, ushort type, IEntity pEntity){
            var owner = pEntity as GameEntity;
            var createPos = pos + DirUtil.GetDirLVec(dir) * TankUtil.TANK_HALF_LEN;
            var entity = CreateUnit(createPos, EntityUtil.CreateEntityBullet(_gameContext, type), dir);
            entity.bullet.ownerLocalId = owner.entityId.value;
            entity.unit.camp = owner.unit.camp;
            entity.collider.radius = new LFloat(null,300);
            entity.collider.size = LVector2.zero;
        }

        public void CreateEnemy(LVector2 bornPos){
            var type = EnemyStartId + _randomService.Range(0, 5);
            CreateEnemy(bornPos, (ushort) type);
        }

        public void CreateEnemy(LVector2 bornPos, ushort type){
            var createPos = bornPos + LVector2.right;
            _gameEffectService.ShowBornEffect(createPos);
            _gameAudioService.PlayClipBorn();
            EDir dir = EDir.Down;
            DelayCall(_gameConfigService.TankBornDelay,
                () => {
                   var entity =  CreateUnit(createPos, EntityUtil.CreateEntityEnemy(_gameContext, type),
                        dir);
                   entity.unit.camp = ECampType.Enemy;
               });
        }

        public void CreatePlayer(byte actorId, ushort type){
            var bornPos = _gameConstStateService.playerBornPoss[actorId % _gameConstStateService.playerBornPoss.Count];
            var createPos = bornPos + _gameConfigService.TankBornOffset;
            _gameEffectService.ShowBornEffect(createPos);
            _gameAudioService.PlayClipBorn();
            EDir dir = EDir.Up;
            DelayCall(_gameConfigService.TankBornDelay, () => {
                var entity = CreateUnit(createPos, EntityUtil.CreateEntityPlayer(_gameContext, type), dir);
                entity.unit.camp = ECampType.Player;
                var actor = _actorContext.GetEntityWithActorId(actorId);
                if (actor != null) {
                    actor.ReplaceGameEntityId(entity.entityId.value);
                    entity.ReplaceActorId(actorId);
                }
                else {
                    Debug.LogError(
                        $"can not find a actor after create a game player actorId:{actorId} entityId{entity.entityId.value}");
                }
            });
        }


        private GameEntity CreateUnit(LVector2 createPos, GameEntity entity, EDir dir){
            var assetId = entity.asset.assetId;
            entity.AddEntityId(_gameStateService.localEntityId);
            _gameStateService.localEntityId++;
            entity.collider.size = LVector2.one;
            entity.collider.radius = LVector2.one.magnitude;
            entity.dir.value = dir;
            entity.pos.value = createPos;
            if (!_constStateService.IsVideoLoading) {
                _viewService.BindView(entity, assetId, createPos);
            }

            return entity;
        }


        public void Upgrade(IEntity iEntity){
            var entity = iEntity as GameEntity;
            var targetKey = entity.asset.assetId + 1;
            if (!Table_ConfigPlayer.HasData(targetKey)) {
                Debug.Log($"hehe already max level can not upgrade");
                return;
            }

            var rawPos = entity.pos.value;
            var rawDir = entity.dir.value;
            var tblData = Table_ConfigPlayer.GetData(targetKey);
            tblData.AssignToEntity(entity);
            entity.pos.value = rawPos;
            entity.dir.value = rawDir;
            if (!_constStateService.IsVideoLoading) {
                _viewService.DeleteView(entity.entityId.value);
                _viewService.BindView(entity, (ushort) entity.asset.assetId, rawPos, DirUtil.GetDirDeg(rawDir));
            }
        }

        public void DelayCall(LFloat delay, Action callback){
            callback();
            //这里可能导致不一致
            //delayEntity.AddDelayCall(delay, DelayCallService.RegisterFunc(callback));
        }

    }
}
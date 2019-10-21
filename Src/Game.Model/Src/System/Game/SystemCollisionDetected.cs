using System.Collections.Generic;
using Entitas;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game {
    public class SystemCollisionDetected : BaseSystem, IExecuteSystem {
        IGroup<GameEntity> allPlayer;
        IGroup<GameEntity> allBullet;
        IGroup<GameEntity> allEnmey;
        IGroup<GameEntity> allItem;
        IGroup<GameEntity> allCamp;

        protected override void DoInit(){
            allPlayer = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.ActorId));
            allBullet = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.TagBullet));

            allEnmey = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.TagEnemy));

            allItem = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.ItemType));
            
            allCamp = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.TagCamp));
        }


        public void Execute(){
            // bullet and tank
            foreach (var bullet in allBullet) {
                if (bullet.isDestroyed) continue;
                var bulletCamp = bullet.unit.camp;
                 foreach (var tank in allPlayer) {
                    if (tank.isDestroyed) continue;
                    if (tank.unit.camp != bulletCamp 
                        ) {
                        if (GameCollisionUtil.CheckCollision(bullet, tank)) {
                            _gameAudioService.PlayClipHitTank();
                            _gameUnitService.TakeDamage(bullet,tank );
                        }

                    }
                }

                foreach (var tank in allEnmey) {
                    if (tank.isDestroyed) continue;
                    if (tank.unit.camp != bulletCamp && GameCollisionUtil.CheckCollision(bullet, tank)) {
                        _gameAudioService.PlayClipHitTank();
                        _gameUnitService.TakeDamage(bullet,tank );
                    }
                }
            }
   
            // bullet and camp
            foreach (var camp in allCamp) {
                foreach (var bullet in allBullet) {
                    if (bullet.isDestroyed) continue;
                    if (camp.isDestroyed) continue;
                    if (GameCollisionUtil.CheckCollision(bullet, camp)) {
                        _gameAudioService.PlayClipHitTank();
                        _gameUnitService.TakeDamage(bullet,camp);
                    }
                }
            }

            HashSet<LVector2Int> tempPoss = new HashSet<LVector2Int>();
            // bullet and map
            foreach (var bullet in allBullet) {
                if (bullet.isDestroyed) continue;
                var pos = bullet.pos.value;
                LVector2 borderDir = DirUtil.GetBorderDir(bullet.dir.value);
                var borderPos1 = pos + borderDir * bullet.collider.radius;
                var borderPos2 = pos - borderDir * bullet.collider.radius;
                tempPoss.Add(pos.Floor());
                tempPoss.Add(borderPos1.Floor());
                tempPoss.Add(borderPos2.Floor());
                foreach (var iPos in tempPoss) {
                    TilemapUtil.CheckBulletWithMap(iPos, bullet, _gameAudioService,_map2DService);
                }

                if (bullet.unit.health == 0) {
                    bullet.isDestroyed = true;
                }

                tempPoss.Clear();
            }

            var min = _gameConstStateService.MapMin;
            var max = _gameConstStateService.MapMax;
            // bullet bound detected 
            foreach (var bullet in allBullet) {
                if (_gameCollisionService.IsOutOfBound(bullet.pos.value, min, max)) {
                    bullet.isDestroyed = true;
                }
            }

            // tank  and item
            //var players = allPlayer.ToArray(); //item may modified the allPlayer list so copy it
            foreach (var player in allPlayer) {
                if (player.isDestroyed) continue;
                foreach (var item in allItem) {
                    if (item.isDestroyed) continue;
                    if (GameCollisionUtil.CheckCollision(player, item)) {
                        _gameAudioService.PlayMusicGetItem();
                        item.itemType.killerActorId = player.actorId.value;
                        item.isDestroyed = true;
                    }
                }
            }
        }
    }
}
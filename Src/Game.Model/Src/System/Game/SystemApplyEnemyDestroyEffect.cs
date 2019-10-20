using Entitas;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game {
    public class SystemApplyEnemyDestroyEffect : BaseSystem, IExecuteSystem {
        IGroup<GameEntity> _destroyedGroup;

        protected override void DoInit(){
            _destroyedGroup = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destroyed,
                GameMatcher.EntityId,
                GameMatcher.TagEnemy));
        }


        public void Execute(){
            foreach (var entity in _destroyedGroup.GetEntities()) {
                var tank = entity.unit;
                _gameEffectService.ShowDiedEffect(entity.pos.value);
                _gameAudioService.PlayClipDied();
                var killerGameEntity = _gameContext.GetEntityWithEntityId(tank.killerLocalId);
                if (entity.hasDropRate) {
                    _gameUnitService.DropItem(entity.dropRate.value);
                }
                _gameStateService.curEnemyCountInScene--;

                if (killerGameEntity == null) return;
                var killerActor = _actorContext.GetEntityWithActorId(killerGameEntity.actorId.value);
                killerActor.score.value += ( +1) * 100;
            }
        }
    }
}
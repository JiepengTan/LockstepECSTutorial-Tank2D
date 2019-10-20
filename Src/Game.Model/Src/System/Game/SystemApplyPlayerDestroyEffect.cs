using Entitas;
using Lockstep.Logging;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game {

    public class SystemApplyPlayerDestroyEffect : BaseSystem, IExecuteSystem {
        IGroup<GameEntity> _destroyedGroup;

        protected override void DoInit(){
            _destroyedGroup = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destroyed,
                GameMatcher.EntityId,
                GameMatcher.ActorId));
        }


        public void Execute(){
            foreach (var entity in _destroyedGroup.GetEntities()) {
                _gameEffectService.ShowDiedEffect(entity.pos.value);
                _gameAudioService.PlayClipDied();
                var actor = _actorContext. GetEntityWithActorId(entity.actorId.value);
                Debug.Assert(actor != null, " player's tank have no owner");
                if (actor.life.value > 0) {
                    _gameUnitService.CreatePlayer(entity.actorId.value, 5001);
                }
            }
        }
    }
}
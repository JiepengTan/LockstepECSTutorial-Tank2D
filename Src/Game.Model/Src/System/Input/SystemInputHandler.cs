using System.Linq;
using Entitas;
using Lockstep.Logging;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Input {
    public class SystemInputHandler : BaseSystem, IExecuteSystem {
        IGroup<InputEntity> _inputGroup;
        public override BaseSystem DoInit(Contexts contexts, IServiceContainer serviceContainer){
            base.DoInit(contexts, serviceContainer);
            _inputGroup = contexts.input.GetGroup(InputMatcher.AllOf(
                InputMatcher.InputInfo,
                InputMatcher.ActorId,
                InputMatcher.Tick));
            return this;
        }
        public void Execute(){
            var es = _inputGroup.GetEntities();
            foreach (var input in 
                es.Where(entity => entity.tick.value == _gameStateContext.tick.value)) {
                var actorEntity = _actorContext.GetEntityWithActorId(input.actorId.value);
                if (!actorEntity.hasGameEntityId) continue;
                var gameLocalId = actorEntity.gameEntityId.value;
                var gameEntity =  _gameContext.GetEntityWithEntityId(gameLocalId);
                if (gameEntity != null) {
                    var inputInfo = input.inputInfo;
                    var dir = (EDir) inputInfo.deg;
                    if (dir != EDir.EnumCount) {
                        gameEntity.ReplaceMoveRequest(dir);
                        if (gameEntity.dir.value != dir) {
                            gameEntity.move.isChangedDir = true;
                        }
                        gameEntity.dir.value = dir;
                    }
                    if (inputInfo.skills != 0) {
                        gameEntity.isFireRequest = true;
                    }
                }
            }
        }
    }
}
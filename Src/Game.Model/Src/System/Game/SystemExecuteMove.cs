using Entitas;
using Lockstep.Logging;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game {
    public class SystemExecuteMove : BaseSystem, IExecuteSystem {
        private IGroup<GameEntity> _group;

        public override BaseSystem DoInit(Contexts contexts, IServiceContainer serviceContainer){
            base.DoInit(contexts, serviceContainer);
            _group = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.Pos,
                GameMatcher.Move));
            return this;
        }

        public void Execute(){
            Debug.LogError("");
            foreach (var entity in _group.GetEntities()) {
                var move = entity.move;
                var dirVec = DirUtil.GetDirLVec(entity.dir.value);
                var offset = (move.moveSpd * new LFloat(null, 16)) * dirVec;
                //entity.pos.value = entity.pos.value + offset;
            }
        }
    }
}
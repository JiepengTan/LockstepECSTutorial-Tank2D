using Entitas;
using Lockstep.ECS.GameState;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game {
    public class SystemApplyCampDestroyEffect : BaseSystem, IExecuteSystem {
        IGroup<GameEntity> _destroyedGroup;

        protected override void DoInit(){
            _destroyedGroup = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destroyed,
                GameMatcher.EntityId,
                GameMatcher.TagCamp));
        }


        public void Execute(){
            
        }
    }
}
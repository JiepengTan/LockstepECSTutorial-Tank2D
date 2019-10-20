using Entitas;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game  {
    public class SystemSkillUpdate :BaseSystem, IExecuteSystem {
        IGroup<GameEntity> _skillGroup;

        protected override void DoInit(){
            _skillGroup = contexts.game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EntityId,
                GameMatcher.Skill));
        }

        public void Execute(){
            foreach (var entity in _skillGroup.GetEntities()) {
                var skill = entity.skill;
                skill.cdTimer -= _gameStateService.DeltaTime;
                if (skill.cdTimer < 0) {
                    skill.cdTimer = LFloat.zero;
                }
            }
        }
    }
}
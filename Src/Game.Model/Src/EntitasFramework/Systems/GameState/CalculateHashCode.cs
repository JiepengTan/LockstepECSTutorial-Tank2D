using Entitas;
using Lockstep.Math;
using Lockstep.Util;

namespace Lockstep.ECS.Systems.GameState {
    public class CalculateHashCode : IInitializeSystem, IExecuteSystem {
        private readonly IGroup<GameEntity> _hashableEntities;

        private readonly GameStateContext _gameStateContext;

        public CalculateHashCode(Contexts contexts){
            _gameStateContext = contexts.gameState;
            _hashableEntities = contexts.game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.EntityId,
                    GameMatcher.Pos
                )
                .NoneOf(GameMatcher.Backup));
        }

        public void Initialize(){
            _gameStateContext.ReplaceHashCode(0);
        }

        public void Execute(){
            int hashCode = 0;
            int idx = 0;
            hashCode += _hashableEntities.count.GetHash(ref idx)* PrimerLUT.GetPrimer(idx++);;
            foreach (var entity in _hashableEntities) {
                hashCode += entity.pos.value.GetHash(ref idx)* PrimerLUT.GetPrimer(idx++);;
                if (entity.hasDir) {
                    hashCode += ((int)entity.dir.value).GetHash(ref idx)* PrimerLUT.GetPrimer(idx++);
                }
            }

            _gameStateContext.ReplaceHashCode(hashCode);
        }
    }
}
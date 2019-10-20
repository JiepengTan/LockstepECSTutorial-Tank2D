using Entitas;
using Lockstep.ECS.Systems.Actor;
using Lockstep.ECS.Systems.Debugging;
using Lockstep.ECS.Systems.GameState;
using Lockstep.Game;

namespace Lockstep.ECS.Systems {
    public sealed class WorldSystems : Feature {
        public WorldSystems(Contexts contexts,IServiceContainer services, Feature logicFeature){
            Add(new InitializeEntityCount(contexts));
            // after game has init, backup before game logic
            Add(new OnPredictionCreateSnapshot(contexts));
            Add(new CalculateHashCode(contexts));
            //game logic
            if (logicFeature != null) {
                Add(logicFeature);    
            }
            //Performance-hit, only use for serious debugging
            //Add(new VerifyNoDuplicateBackups(contexts));             

            Add(new CleanDestroyedGameEntities(contexts));
            Add(new CleanDestroyedInputEntities(contexts));
            Add(new IncrementTick().DoInit(contexts,services));
        }
    }
}
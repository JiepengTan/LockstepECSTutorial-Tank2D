using Lockstep.Game.Systems.GameState;

namespace Lockstep.Game.Features {
    sealed class GameInitStateFeature : Feature {
        public GameInitStateFeature(Contexts contexts, IServiceContainer services) : base("GameInitState"){
            Add(new SystemGameInit().DoInit(contexts, services));
        }
    }
}
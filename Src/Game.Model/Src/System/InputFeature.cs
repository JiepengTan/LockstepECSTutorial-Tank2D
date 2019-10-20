using Lockstep.Game.Systems.Input;

namespace Lockstep.Game.Features {
    sealed class InputFeature : Feature {
        public InputFeature(Contexts contexts, IServiceContainer services) : base("Input"){
            Add(new SystemInputHandler().DoInit(contexts, services));
        }
    }
}
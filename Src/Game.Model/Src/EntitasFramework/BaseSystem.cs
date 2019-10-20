using Entitas;

namespace Lockstep.Game {
    public class BaseSystem : BaseSystemReferenceHolder, ISystem {

        protected Contexts contexts;
        public virtual BaseSystem DoInit(Contexts contexts, IServiceContainer serviceContainer){
            this.contexts = contexts;
            InitReference(contexts);
            InitReference(serviceContainer);
            DoInit();
            return this;
        }

        protected virtual void DoInit(){
            
        }
    }
}
using System.Collections.Generic;
using System.Reflection;
using Lockstep.ECS;

namespace Lockstep.Game {
    public class EntitasECSFactoryService : IECSFactoryService {
        private static Contexts lastInstance;
        public object CreateSystems(object contexts, IServiceContainer services){
            return new GameLogicSystems(contexts as Contexts,services) ;
        }
        

        public object CreateContexts(){
            Contexts ctxs = null;
            if (lastInstance == null) {
                ctxs = Contexts.sharedInstance;
            }
            else {
                ctxs = new Contexts();
            }

            lastInstance = ctxs;
            return ctxs;
        }
    }
}
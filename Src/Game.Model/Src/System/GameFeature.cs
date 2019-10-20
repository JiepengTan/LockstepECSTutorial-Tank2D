using Lockstep.Game.Systems.Game;

namespace Lockstep.Game.Features {
    sealed class GameFeature : Feature {
        private Contexts contexts;
        private IServiceContainer services;
        public GameFeature(Contexts contexts, IServiceContainer services) : base("Game"){
            this.contexts = contexts;
            this.services = services;
            AddSystem(new SystemDelayCall());
            //Spawn
            AddSystem(new SystemEnemyBorn());
            //AI
            AddSystem(new SystemUpdateAI());
            //Skill
            AddSystem(new SystemExecuteFire());
            AddSystem(new SystemSkillUpdate());
            //Move
            AddSystem(new SystemExecuteMoveBullet());
            AddSystem(new SystemExecuteMoveTank());
            AddSystem(new SystemExecuteMovePlayer());
            //CollisionDetected
            AddSystem(new SystemCollisionDetected());
            //Destroy
            AddSystem(new SystemApplyCampDestroyEffect());
            AddSystem(new SystemApplyItemDestroyEffect());
            AddSystem(new SystemApplyPlayerDestroyEffect());
            AddSystem(new SystemApplyEnemyDestroyEffect());
        }

        void AddSystem(BaseSystem system){
            Add(system);
            system.DoInit(contexts, services);
        }
    }
}
﻿using Entitas;

namespace Lockstep.ECS.Systems.Actor
{
    public class InitializeEntityCount : IInitializeSystem
    {
        private readonly ActorContext _actorContext;

        public InitializeEntityCount(Contexts contexts)
        {
            _actorContext = contexts.actor;
        }
        public void Initialize()
        {
            
        }
    }
}

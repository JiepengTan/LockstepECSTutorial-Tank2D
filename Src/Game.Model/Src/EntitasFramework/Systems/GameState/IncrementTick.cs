﻿using Entitas;
using Lockstep.Game;

namespace Lockstep.ECS.Systems.GameState {
    public class IncrementTick : BaseSystem, IInitializeSystem, IExecuteSystem {
        
        public void Initialize(){
            _gameStateContext.SetTick(0);
        }

        public void Execute(){
            var tick = _gameStateContext.tick.value;
            _gameStateContext.ReplaceTick(tick + 1);
        }
    }
}
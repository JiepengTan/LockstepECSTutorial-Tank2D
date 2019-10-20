﻿using System.Collections.Generic;
using Entitas;
using Lockstep.Logging;

namespace Lockstep.ECS.Systems.Debugging
{
    public class VerifyNoDuplicateBackups : IExecuteSystem
    {                                                       
        private readonly IGroup<GameEntity> _backups;

        public VerifyNoDuplicateBackups(Contexts contexts)
        {                                                 
            _backups = contexts.game.GetGroup(GameMatcher.Backup);
        }
        public void Execute()
        {
            var temp = new Dictionary<int, List<uint>>();
            foreach (var entity in _backups)
            {
                if (temp.ContainsKey(entity.backup.tick))
                {         
                    if (temp[entity.backup.tick].Contains(entity.backup.entityId))
                    {     
                        Logger.Warn(this, "Backup duplicate: " + 
                                          temp[entity.backup.tick].Count + " backups in tick "+
                                          entity.backup.tick +" are already pointing to " + entity.backup.entityId);
                    }    
                }
                else
                {
                    temp.Add(entity.backup.tick, new List<uint>());
                }

                temp[entity.backup.tick].Add(entity.backup.entityId);
            }
        }
    }
}

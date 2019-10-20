using System.Collections.Generic;
using Lockstep.ECS;
using Lockstep.Math;
using Lockstep.Serialization;
using NetMsg.Common;

namespace Lockstep.Game {
    public interface IGameConfigService : IService {
        short BornPrefabAssetId { get; }
        short DiedPrefabAssetId { get; }
        
        float BornEnemyInterval { get; }
        int MaxEnemyCount { get; }
        int InitEnemyCount { get; }

        int MaxPlayerCount { get; }
        LVector2 TankBornOffset { get; }
        LFloat TankBornDelay { get; }
        [NoGenCode]
        LFloat DeltaTime { get; }
        string RelPath {get; set; }
        
        CollisionConfig CollisionConfig { get; }
        string RecorderFilePath { get; }
        string DumpStrPath { get; }
        Msg_G2C_GameStartInfo ClientModeInfo{ get; }
    }
}
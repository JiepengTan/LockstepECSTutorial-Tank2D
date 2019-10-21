using System.Collections.Generic;
using Lockstep.ECS.ECDefine;
using Lockstep.Math;
using Lockstep.Serialization;
using NetMsg.Common;
using System;
namespace Lockstep.Game {
    public class GameStateService : IGameStateService {
        //changed in the game
        public LFloat BornInterval;
        public LFloat BornTimer;
        public Int32 CurEnemyCountInScene;
        public UInt32 LocalEntityId;
        public Int32 RemainCountToBorn;
    }

    public class GameConstStateService : IGameConstStateService {
        public int MaxPlayerCount;
        public bool IsPlaying;

        public int PlayerInitLifeCount;

        public LVector2Int MapMin;
        public LVector2Int MapMax;

        public List<LVector2> EnemyBornPoints;
        public List<LVector2> PlayerBornPoss;
        public LVector2 CampPos;

        public int MaxEnemyCountInScene;
        public int TotalEnemyCountToBorn;
    }

    public class GameConfigService : IGameConfigService {
        public short BornPrefabAssetId;
        public short DiedPrefabAssetId;

        public float BornEnemyInterval;
        public int MaxEnemyCount;
        public int InitEnemyCount;

        public int MaxPlayerCount;
        public LVector2 TankBornOffset;
        public LFloat TankBornDelay;
        public string RelPath;

        public CollisionConfig CollisionConfig;
        public string RecorderFilePath;
        public string DumpStrPath;
        public Msg_G2C_GameStartInfo ClientModeInfo;
    }
}
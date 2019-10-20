using System.Collections.Generic;
using Lockstep.Math;
using NetMsg.Common;

namespace Lockstep.Game {
    public interface IGameConstStateService : IService {
        int MaxPlayerCount { get; }
        bool IsPlaying { get; set; }

        int playerInitLifeCount { get; }

        LVector2Int mapMin { get; set; }
        LVector2Int mapMax { get; set; }

        List<LVector2> enemyBornPoints { get; set; }
        List<LVector2> playerBornPoss { get; set; }
        LVector2 campPos { get; set; }


        int MaxEnemyCountInScene { get; set; }
        int TotalEnemyCountToBorn { get; set; }
    }
}
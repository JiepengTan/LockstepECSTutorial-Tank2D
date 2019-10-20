using Lockstep.Math;
using Lockstep.Serialization;

namespace Lockstep.Game {
    public interface IGameStateService : IService {
        //changed in the game
        int curEnemyCountInScene { get; set; }
        int remainCountToBorn { get; set; }
        LFloat bornTimer { get; set; }
        LFloat bornInterval { get; set; }
        uint localEntityId { get; set; }
        [NoGenCode]
        LFloat DeltaTime { get; set; }
    }
}
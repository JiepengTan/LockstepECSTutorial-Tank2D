using Lockstep.Math;
using Lockstep.Serialization;

namespace Lockstep.Game {
    public partial interface IGameStateService : IService {
        [NoGenCode]
        LFloat DeltaTime { get; set; }
    }
}
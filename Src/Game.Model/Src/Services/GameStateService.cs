
using Lockstep.Math;

namespace Lockstep.Game {

    public partial class GameStateService :BaseService
        ,IGameStateService //
    {
        public static GameStateService Instance { get; private set; }
        public GameStateService(){
            Instance = this;
        }
        
        public LFloat DeltaTime {
            get => _deltaTime;
            set => _deltaTime = value;
        }
        private LFloat _deltaTime = new LFloat(null, 30);
        
    }
}
namespace Lockstep.Game {
    
    public partial class GameService :BaseGameService{
        protected IGameStateService _gameStateService;
        protected IGameEffectService _gameEffectService;
        protected IGameAudioService _gameAudioService;
        protected IGameConfigService _gameConfigService;
        protected IGameResourceService _gameResourceService;
        protected IGameConstStateService _gameConstStateService;
        protected IGameUnitService _gameUnitService;
        protected IGameCollision2DService _gameCollision2DService;
        
        protected override void OnInitReference(IServiceContainer serviceContainer, IManagerContainer mgrContainer){
          
            _gameEffectService = serviceContainer.GetService<IGameEffectService>();
            _gameAudioService = serviceContainer.GetService<IGameAudioService>();
            _gameStateService = serviceContainer.GetService<IGameStateService>();
            _gameConfigService = serviceContainer.GetService<IGameConfigService>();
            _gameResourceService = serviceContainer.GetService<IGameResourceService>();
            _gameConstStateService = serviceContainer.GetService<IGameConstStateService>();
            _gameCollision2DService = serviceContainer.GetService<IGameCollision2DService>();
            _gameUnitService = serviceContainer.GetService<IGameUnitService>();
        }
    }
}
namespace Lockstep.Game {
    public class BaseSystemReferenceHolder :ServiceReferenceHolder{
        protected InputContext _inputContext;
        protected ActorContext _actorContext;
        protected GameContext _gameContext;
        protected GameStateContext _gameStateContext;
        
        
        public virtual void InitReference(Contexts contexts){
            _actorContext = contexts.actor;
            _inputContext = contexts.input;
            _gameContext = contexts.game;
            _gameStateContext = contexts.gameState;
        }
        
        
        protected IGameStateService _gameStateService;
        protected IGameEffectService _gameEffectService;
        protected IGameAudioService _gameAudioService;
        protected IGameConfigService _gameConfigService;
        protected IGameConstStateService _gameConstStateService;
        protected IGameUnitService _gameUnitService;
        protected IGameCollision2DService _gameCollisionService;
        

        public override void InitReference(IServiceContainer serviceContainer,IManagerContainer mgrContainer = null){
            base.InitReference(serviceContainer,mgrContainer);
            _gameEffectService = serviceContainer.GetService<IGameEffectService>();
            _gameAudioService = serviceContainer.GetService<IGameAudioService>();
            _gameStateService = serviceContainer.GetService<IGameStateService>();
            _gameConfigService = serviceContainer.GetService<IGameConfigService>();
            _gameCollisionService = serviceContainer.GetService<IGameCollision2DService>();
            _gameConstStateService = serviceContainer.GetService<IGameConstStateService>();
            _gameUnitService = serviceContainer.GetService<IGameUnitService>();
        }
    }
}
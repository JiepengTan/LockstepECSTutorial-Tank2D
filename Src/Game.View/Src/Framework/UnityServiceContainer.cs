using Lockstep.Game;


public class UnityServiceContainer : BaseGameServicesContainer {
    public UnityServiceContainer():base(){
        
#if USE_SIMPLE_ECS
        RegisterService(new SimpleGameSystemsFactorService());
#else
        RegisterService(new EntitasECSFactoryService());
#endif

        RegisterService(new GameResourceService());

        RegisterService(new GameStateService());
        RegisterService(new GameConfigService());
        RegisterService(new GameInputService());
        RegisterService(new GameConstStateService());
        
        RegisterService(new UnityMap2DService());
        RegisterService(new GameCollision2DService());
        
        RegisterService(new GameUnitService());
        
        RegisterService(new UnityEffectService());
        RegisterService(new UnityGameEffectService());
        
        RegisterService(new UnityAudioService());
        RegisterService(new UnityGameAudioService());
        
        RegisterService(new UnityViewService());
        RegisterService(new UnityUIService());
    }
}
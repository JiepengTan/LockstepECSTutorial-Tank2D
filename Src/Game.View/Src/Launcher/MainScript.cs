using Lockstep.Game;
using Lockstep.Game.UI;
using UnityEngine;

public class MainScript  : MonoBehaviour {
    public Launcher launcher = new Launcher();
    public int MaxEnemyCount = 10;
    public bool IsClientMode = false;
    public bool IsRunVideo;
    public bool IsVideoMode = false;
    public string RecordFilePath;
    public bool HasInit = false;

    private ServiceContainer _serviceContainer;

    public Camera gameCamera;
    public Vector2Int renderTextureSize;
    [HideInInspector] public RenderTexture rt;

    protected virtual void Awake(){
        Debug.Log(Application.persistentDataPath);
        TableManager.Init(ProjectConfig.ExcelPath);
        UnityEngine.Debug.Log(ProjectConfig.ExcelPath);
        gameObject.AddComponent<PingMono>();
        gameObject.AddComponent<InputMono>();
        _serviceContainer = new UnityServiceContainer();
        _serviceContainer.GetService<IConstStateService>().GameName = ProjectConfig.GameName;
        _serviceContainer.GetService<IConstStateService>().IsClientMode = IsClientMode;
        _serviceContainer.GetService<IConstStateService>().IsVideoMode = IsVideoMode;
        _serviceContainer.GetService<ISimulatorService>().FuncCreateWorld = (services, obj, featureObj) => {
            return new EntitasWorld(services,obj,featureObj);
        }; 
        //_serviceContainer.GetService<IGameStateService>().MaxEnemyCount = MaxEnemyCount;
        Lockstep.Logging.Logger.OnMessage += UnityLogHandler.OnLog;
        Screen.SetResolution(1024, 768, false);
        rt = new RenderTexture(renderTextureSize.x, renderTextureSize.y, 1, RenderTextureFormat.ARGB32);
        gameCamera.targetTexture = rt;
        var service = (UnityUIService) (GetService<IUIService>());
        service.rt = rt;
        service.RegisterAssembly(typeof(UIRoot).Assembly);
        launcher.DoAwake(_serviceContainer);
    }


    private void Start(){
        launcher.DoStart();
        HasInit = true;
    }

    private void Update(){
        _serviceContainer.GetService<IConstStateService>().IsRunVideo = IsVideoMode;
        launcher.DoUpdate(Time.deltaTime);
    }

    private void OnDestroy(){
        launcher.DoDestroy();
    }

    private void OnApplicationQuit(){
        launcher.OnApplicationQuit();
    }

    public T GetService<T>() where T : IService{
        return _serviceContainer.GetService<T>();
    }
}
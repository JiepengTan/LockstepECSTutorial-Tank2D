using Lockstep.Game;

public class MonoProxyMainScript : MainScript {
    protected override void Awake(){
#if UNITY_EDITOR
        ProjectConfig.IsEditor = true;
        UnityEngine.Debug.Log("ProjectConfig.IsBuildWithUnity " + ProjectConfig.IsBuildWithUnity);

        ProjectConfig.DoInit();
#endif
        base.Awake();
    }
}
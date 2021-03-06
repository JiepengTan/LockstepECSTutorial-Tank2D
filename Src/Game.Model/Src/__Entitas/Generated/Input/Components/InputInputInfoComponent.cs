//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Lockstep.ECS.Input.InputInfoComponent inputInfo { get { return (Lockstep.ECS.Input.InputInfoComponent)GetComponent(InputComponentsLookup.InputInfo); } }
    public bool hasInputInfo { get { return HasComponent(InputComponentsLookup.InputInfo); } }

    public void AddInputInfo(ushort newDeg, ushort newSkills) {
        var index = InputComponentsLookup.InputInfo;
        var component = (Lockstep.ECS.Input.InputInfoComponent)CreateComponent(index, typeof(Lockstep.ECS.Input.InputInfoComponent));
        component.deg = newDeg;
        component.skills = newSkills;
        AddComponent(index, component);
    }

    public void ReplaceInputInfo(ushort newDeg, ushort newSkills) {
        var index = InputComponentsLookup.InputInfo;
        var component = (Lockstep.ECS.Input.InputInfoComponent)CreateComponent(index, typeof(Lockstep.ECS.Input.InputInfoComponent));
        component.deg = newDeg;
        component.skills = newSkills;
        ReplaceComponent(index, component);
    }

    public void RemoveInputInfo() {
        RemoveComponent(InputComponentsLookup.InputInfo);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputInfo;

    public static Entitas.IMatcher<InputEntity> InputInfo {
        get {
            if (_matcherInputInfo == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputInfo);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputInfo = matcher;
            }

            return _matcherInputInfo;
        }
    }
}

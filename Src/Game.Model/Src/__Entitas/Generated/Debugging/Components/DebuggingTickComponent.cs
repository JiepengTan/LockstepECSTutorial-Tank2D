//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DebuggingEntity {

    public Lockstep.ECS.Debugging.TickComponent tick { get { return (Lockstep.ECS.Debugging.TickComponent)GetComponent(DebuggingComponentsLookup.Tick); } }
    public bool hasTick { get { return HasComponent(DebuggingComponentsLookup.Tick); } }

    public void AddTick(uint newValue) {
        var index = DebuggingComponentsLookup.Tick;
        var component = (Lockstep.ECS.Debugging.TickComponent)CreateComponent(index, typeof(Lockstep.ECS.Debugging.TickComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTick(uint newValue) {
        var index = DebuggingComponentsLookup.Tick;
        var component = (Lockstep.ECS.Debugging.TickComponent)CreateComponent(index, typeof(Lockstep.ECS.Debugging.TickComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTick() {
        RemoveComponent(DebuggingComponentsLookup.Tick);
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
public sealed partial class DebuggingMatcher {

    static Entitas.IMatcher<DebuggingEntity> _matcherTick;

    public static Entitas.IMatcher<DebuggingEntity> Tick {
        get {
            if (_matcherTick == null) {
                var matcher = (Entitas.Matcher<DebuggingEntity>)Entitas.Matcher<DebuggingEntity>.AllOf(DebuggingComponentsLookup.Tick);
                matcher.componentNames = DebuggingComponentsLookup.componentNames;
                _matcherTick = matcher;
            }

            return _matcherTick;
        }
    }
}

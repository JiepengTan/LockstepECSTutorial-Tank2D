//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity {

    public Lockstep.ECS.Actor.ActorIdComponent actorId { get { return (Lockstep.ECS.Actor.ActorIdComponent)GetComponent(ActorComponentsLookup.ActorId); } }
    public bool hasActorId { get { return HasComponent(ActorComponentsLookup.ActorId); } }

    public void AddActorId(byte newValue) {
        var index = ActorComponentsLookup.ActorId;
        var component = (Lockstep.ECS.Actor.ActorIdComponent)CreateComponent(index, typeof(Lockstep.ECS.Actor.ActorIdComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceActorId(byte newValue) {
        var index = ActorComponentsLookup.ActorId;
        var component = (Lockstep.ECS.Actor.ActorIdComponent)CreateComponent(index, typeof(Lockstep.ECS.Actor.ActorIdComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveActorId() {
        RemoveComponent(ActorComponentsLookup.ActorId);
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
public sealed partial class ActorMatcher {

    static Entitas.IMatcher<ActorEntity> _matcherActorId;

    public static Entitas.IMatcher<ActorEntity> ActorId {
        get {
            if (_matcherActorId == null) {
                var matcher = (Entitas.Matcher<ActorEntity>)Entitas.Matcher<ActorEntity>.AllOf(ActorComponentsLookup.ActorId);
                matcher.componentNames = ActorComponentsLookup.componentNames;
                _matcherActorId = matcher;
            }

            return _matcherActorId;
        }
    }
}

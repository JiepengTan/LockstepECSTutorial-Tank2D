//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity {

    public Lockstep.ECS.Actor.LifeComponent life { get { return (Lockstep.ECS.Actor.LifeComponent)GetComponent(ActorComponentsLookup.Life); } }
    public bool hasLife { get { return HasComponent(ActorComponentsLookup.Life); } }

    public void AddLife(int newValue) {
        var index = ActorComponentsLookup.Life;
        var component = (Lockstep.ECS.Actor.LifeComponent)CreateComponent(index, typeof(Lockstep.ECS.Actor.LifeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLife(int newValue) {
        var index = ActorComponentsLookup.Life;
        var component = (Lockstep.ECS.Actor.LifeComponent)CreateComponent(index, typeof(Lockstep.ECS.Actor.LifeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLife() {
        RemoveComponent(ActorComponentsLookup.Life);
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

    static Entitas.IMatcher<ActorEntity> _matcherLife;

    public static Entitas.IMatcher<ActorEntity> Life {
        get {
            if (_matcherLife == null) {
                var matcher = (Entitas.Matcher<ActorEntity>)Entitas.Matcher<ActorEntity>.AllOf(ActorComponentsLookup.Life);
                matcher.componentNames = ActorComponentsLookup.componentNames;
                _matcherLife = matcher;
            }

            return _matcherLife;
        }
    }
}
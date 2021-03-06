//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Lockstep.ECS.Game.DropRateComponent dropRate { get { return (Lockstep.ECS.Game.DropRateComponent)GetComponent(GameComponentsLookup.DropRate); } }
    public bool hasDropRate { get { return HasComponent(GameComponentsLookup.DropRate); } }

    public void AddDropRate(Lockstep.Math.LFloat newValue) {
        var index = GameComponentsLookup.DropRate;
        var component = (Lockstep.ECS.Game.DropRateComponent)CreateComponent(index, typeof(Lockstep.ECS.Game.DropRateComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDropRate(Lockstep.Math.LFloat newValue) {
        var index = GameComponentsLookup.DropRate;
        var component = (Lockstep.ECS.Game.DropRateComponent)CreateComponent(index, typeof(Lockstep.ECS.Game.DropRateComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDropRate() {
        RemoveComponent(GameComponentsLookup.DropRate);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDropRate;

    public static Entitas.IMatcher<GameEntity> DropRate {
        get {
            if (_matcherDropRate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DropRate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDropRate = matcher;
            }

            return _matcherDropRate;
        }
    }
}

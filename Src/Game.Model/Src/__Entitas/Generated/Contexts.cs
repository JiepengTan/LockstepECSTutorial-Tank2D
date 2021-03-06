//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public ActorContext actor { get; set; }
    public ConfigContext config { get; set; }
    public DebuggingContext debugging { get; set; }
    public GameContext game { get; set; }
    public GameStateContext gameState { get; set; }
    public InputContext input { get; set; }
    public SnapshotContext snapshot { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { actor, config, debugging, game, gameState, input, snapshot }; } }

    public Contexts() {
        actor = new ActorContext();
        config = new ConfigContext();
        debugging = new DebuggingContext();
        game = new GameContext();
        gameState = new GameStateContext();
        input = new InputContext();
        snapshot = new SnapshotContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string ActorId = "ActorId";
    public const string EntityId = "EntityId";
    public const string Tick = "Tick";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        actor.AddEntityIndex(new Entitas.PrimaryEntityIndex<ActorEntity, byte>(
            ActorId,
            actor.GetGroup(ActorMatcher.ActorId),
            (e, c) => ((Lockstep.ECS.Actor.ActorIdComponent)c).value));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, uint>(
            EntityId,
            game.GetGroup(GameMatcher.EntityId),
            (e, c) => ((Lockstep.ECS.Game.EntityIdComponent)c).value));

        snapshot.AddEntityIndex(new Entitas.PrimaryEntityIndex<SnapshotEntity, int>(
            Tick,
            snapshot.GetGroup(SnapshotMatcher.Tick),
            (e, c) => ((Lockstep.ECS.Snapshot.TickComponent)c).value));
    }
}

public static class ContextsExtensions {

    public static ActorEntity GetEntityWithActorId(this ActorContext context, byte value) {
        return ((Entitas.PrimaryEntityIndex<ActorEntity, byte>)context.GetEntityIndex(Contexts.ActorId)).GetEntity(value);
    }

    public static GameEntity GetEntityWithEntityId(this GameContext context, uint value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, uint>)context.GetEntityIndex(Contexts.EntityId)).GetEntity(value);
    }

    public static SnapshotEntity GetEntityWithTick(this SnapshotContext context, int value) {
        return ((Entitas.PrimaryEntityIndex<SnapshotEntity, int>)context.GetEntityIndex(Contexts.Tick)).GetEntity(value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(actor);
            CreateContextObserver(config);
            CreateContextObserver(debugging);
            CreateContextObserver(game);
            CreateContextObserver(gameState);
            CreateContextObserver(input);
            CreateContextObserver(snapshot);
        } catch(System.Exception) {
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}

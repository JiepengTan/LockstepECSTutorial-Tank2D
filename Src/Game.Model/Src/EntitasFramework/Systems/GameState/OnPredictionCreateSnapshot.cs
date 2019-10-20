using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace Lockstep.ECS.Systems.GameState
{
    public class OnPredictionCreateSnapshot : ReactiveSystem<GameStateEntity>
    {
        private readonly GameContext _gameContext;
        private readonly ActorContext _actorContext;
        private readonly SnapshotContext _snapshotContext;
        private readonly GameStateContext _gameStateContext;


        private readonly IGroup<ActorEntity> _activeActors;
        private readonly IGroup<GameEntity> _activeEntities;

        public OnPredictionCreateSnapshot(Contexts contexts) : base(contexts.gameState)
        {
            _gameContext = contexts.game;
            _actorContext = contexts.actor;
            _snapshotContext = contexts.snapshot;
            _gameStateContext = contexts.gameState;                                

            _activeActors = contexts.actor.GetGroup(ActorMatcher.ActorId);
            _activeEntities = contexts.game.GetGroup(GameMatcher.EntityId);
        }

        protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
        {   
            //Create a snapshot as soon as prediction starts
            return context.CreateCollector(GameStateMatcher.BackupCurFrame.Added());
        }

        protected override bool Filter(GameStateEntity gameState)
        {
            return gameState.isBackupCurFrame;
        }

        protected override void Execute(List<GameStateEntity> entities)
        {                                             
            var currentTick = _gameStateContext.tick.value;
            //Debug.Log($"Create snapshort {currentTick}");

            //Register the tick for which a snapshot is created
            _snapshotContext.CreateEntity().AddTick(currentTick);     

            foreach (var entity in _activeEntities)
            {
                var shadowEntity = _gameContext.CreateEntity();

                //LocalId is primary index => don't copy; everything else has to be copied in case a destroyed entity has to be recovered
                foreach (var index in entity.GetComponentIndices().Except(new[] { GameComponentsLookup.EntityId }))
                {
                    entity.CopyTo(shadowEntity,index);
                }

                shadowEntity.AddBackup(entity.entityId.value, currentTick);
            }

            foreach (var entity in _activeActors)
            {
                var shadowEntity = _actorContext.CreateEntity();

                //Id is primary index => don't copy
                foreach (var index in entity.GetComponentIndices().Except(new[] { ActorComponentsLookup.ActorId }))
                {
                    entity.CopyTo(shadowEntity,index);
                }

                shadowEntity.AddBackup(entity.actorId.value, currentTick);
            }

          Lockstep.Logging.Logger.Trace(this, "New snapshot for " + currentTick + "(" + _activeActors.count + " actors, " + _activeEntities.count + " entities)");
        }
    }
}

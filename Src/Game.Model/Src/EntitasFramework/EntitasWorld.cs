using System.Collections.Generic;
using System.Linq;
using Entitas;
using Lockstep.ECS.Systems;
using Lockstep.Logging;
using Lockstep.Serialization;
using NetMsg.Common;

namespace Lockstep.Game {
    public class EntitasWorld : World {
        private InputContext _inputContext;
        private ActorContext _actorContext;
        private GameContext _gameContext;
        private GameStateContext _gameStateContext;
        private SnapshotContext _snapshotContext;
        private readonly WorldSystems _systems;
        private Contexts _context;
        public EntitasWorld(IServiceContainer services,object contextsObj, object logicFeatureObj){
            var contexts = contextsObj as Contexts;
            var logicFeature = logicFeatureObj as Feature;
            _context = contexts;
            _actorContext = contexts.actor;
            _gameContext = contexts.game;
            _gameStateContext = contexts.gameState;
            _snapshotContext = contexts.snapshot;

            _timeMachineService = services.GetService<ITimeMachineService>();
            _systems = new WorldSystems(contexts, services, logicFeature);
        }
        protected override void DoSimulateAwake(IServiceContainer serviceContainer, IManagerContainer mgrContainer){
            InitReference(serviceContainer, mgrContainer);
            DoAwake(serviceContainer);
            DoStart();
        }

        protected override void DoSimulateStart(){
            Debug.Log("DoSimulateStart");
            _systems.Initialize();
        }

        protected override void DoBackup(int tick){
            _gameStateContext.isBackupCurFrame = true;
        }

        protected override void DoStep(bool isNeedGenSnap){
            _systems.Execute();
            _systems.Cleanup();
        }

        protected override void DoProcessInputQueue(InputCmd cmd){
            var entity = _context.input.CreateEntity();
            var input = new Deserializer(cmd.content).Parse<PlayerInput>();
            entity.AddInputInfo(input.deg,input.skillId);
            entity.AddTick(Tick);
            entity.AddActorId(0);
            entity.isDestroyed = true;
        }
        protected override void DoRollbackTo(int tick, int missFrameTick, bool isNeedClear = true){
            var snapshotIndices = _snapshotContext.GetEntities(SnapshotMatcher.Tick)
                .Where(entity => entity.tick.value <= tick).Select(entity => entity.tick.value).ToList();
            if (snapshotIndices.Count <= 0) return;
            snapshotIndices.Sort();
            Logging.Debug.Assert(snapshotIndices.Count > 0 && snapshotIndices[0] <= tick,
                $"Error! no correct history frame to revert minTick{(snapshotIndices.Count > 0 ? snapshotIndices[0] : 0)} targetTick {tick}");
            int i = snapshotIndices.Count - 1;
            for (; i >= 0; i--) {
                if (snapshotIndices[i] <= tick) {
                    break;
                }
            }

            var resultTick = snapshotIndices[i];
            if (resultTick == Tick) {
                Logging.Debug.Log("SelfTick should not rollback");
                return;
            }

            var snaps = "";
            foreach (var idx in snapshotIndices) {
                snaps += idx + " ";
            }

            Logging.Debug.Log(
                $"Rolling back {Tick}->{tick} :final from {resultTick} to {_gameStateContext.tick.value}  " +
                $"missTick:{missFrameTick} total:{Tick - resultTick} ");

            /*
             * ====================== Revert actors ======================
             * most importantly: the entity-count per actor gets reverted so the composite key (Id + ActorId) of GameEntities stays in sync
             */

            var backedUpActors =
                _actorContext.GetEntities(ActorMatcher.Backup).Where(e => e.backup.tick == resultTick);
            foreach (var backedUpActor in backedUpActors) {
                var target = _actorContext.GetEntityWithActorId(backedUpActor.backup.actorId);
                if (target == null) {
                    target = _actorContext.CreateEntity();
                    target.AddActorId(backedUpActor.backup.actorId);
                }

                //CopyTo does NOT remove additional existing components, so remove them first
                var additionalComponentIndices = target.GetComponentIndices().Except(
                    backedUpActor.GetComponentIndices()
                        .Except(new[] {ActorComponentsLookup.Backup})
                        .Concat(new[] {ActorComponentsLookup.ActorId}));

                foreach (var index in additionalComponentIndices) {
                    target.RemoveComponent(index);
                }

                backedUpActor.CopyTo(target, true,
                    backedUpActor.GetComponentIndices().Except(new[] {ActorComponentsLookup.Backup}).ToArray());
            }

            /*
            * ====================== Revert game-entities ======================      
            */
            var currentEntities = _gameContext.GetEntities(GameMatcher.EntityId);
            var backupEntities = _gameContext.GetEntities(GameMatcher.Backup).Where(e => e.backup.tick == resultTick)
                .ToList();
            var backupEntityIds = backupEntities.Select(entity => entity.backup.entityId);

            //Entities that were created in the prediction have to be destroyed
            var invalidEntities = currentEntities.Where(entity => !backupEntityIds.Contains(entity.entityId.value))
                .ToList();
            foreach (var invalidEntity in invalidEntities) {
                invalidEntity.isDestroyed = true;
            }


            //Copy old state to the entity                                      
            foreach (var backupEntity in backupEntities) {
                var target = _gameContext.GetEntityWithEntityId(backupEntity.backup.entityId);
                if (target == null) {
                    target = _gameContext.CreateEntity();
                    target.AddEntityId(backupEntity.backup.entityId);
                }

                //CopyTo does NOT remove additional existing components, so remove them first
                var additionalComponentIndices = target.GetComponentIndices().Except(
                    backupEntity.GetComponentIndices()
                        .Except(new[] {GameComponentsLookup.Backup})
                        .Concat(new[] {GameComponentsLookup.EntityId}));

                foreach (var index in additionalComponentIndices) {
                    target.RemoveComponent(index);
                }

                backupEntity.CopyTo(target, true,
                    backupEntity.GetComponentIndices().Except(new[] {GameComponentsLookup.Backup}).ToArray());
            }

            //将太后 和太前的snapshot 删除掉
            if (isNeedClear) {
                foreach (var invalidBackupEntity in _actorContext.GetEntities(ActorMatcher.Backup)
                    .Where(e => e.backup.tick != resultTick)) {
                    invalidBackupEntity.Destroy();
                }

                foreach (var invalidBackupEntity in _gameContext.GetEntities(GameMatcher.Backup)
                    .Where(e => e.backup.tick != resultTick)) {
                    invalidBackupEntity.Destroy();
                }

                foreach (var snapshotEntity in _snapshotContext.GetEntities(SnapshotMatcher.Tick)
                    .Where(e => e.tick.value != resultTick)) {
                    snapshotEntity.Destroy();
                }
            }

            //TODO: restore locally destroyed entities   

            //Cleanup game-entities that are marked as destroyed
            _systems.Cleanup();
            _gameStateContext.ReplaceTick(resultTick);
            _timeMachineService.RollbackTo(resultTick);
        }

        protected virtual void DoCleanUselessSnapshot(int checkedTick){
            if (checkedTick < 2) return;
            //_timeMachineService.Clean(checkedTick-1);
            var snapshotIndices = _snapshotContext.GetEntities(SnapshotMatcher.Tick)
                .Where(entity => entity.tick.value <= checkedTick).Select(entity => entity.tick.value).ToList();
            if (snapshotIndices.Count == 0) return;
            snapshotIndices.Sort();
            int i = snapshotIndices.Count - 1;
            for (; i >= 0; i--) {
                if (snapshotIndices[i] <= checkedTick) {
                    break;
                }
            }

            if (i < 0) return;
            var resultTick = snapshotIndices[i];
            //将太后 和太前的snapshot 删除掉
            foreach (var invalidBackupEntity in _actorContext.GetEntities(ActorMatcher.Backup)
                .Where(e => e.backup.tick < (resultTick))) {
                invalidBackupEntity.Destroy();
            }

            foreach (var invalidBackupEntity in _gameContext.GetEntities(GameMatcher.Backup)
                .Where(e => e.backup.tick < (resultTick))) {
                invalidBackupEntity.Destroy();
            }

            foreach (var snapshotEntity in _snapshotContext.GetEntities(SnapshotMatcher.Tick)
                .Where(e => e.tick.value < (resultTick))) {
                snapshotEntity.Destroy();
            }

            _systems.Cleanup();
        }
    }
}
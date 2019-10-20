using Entitas;
using Lockstep.Logging;
using Lockstep.Math;

namespace Lockstep.Game.Systems.GameState {
    public class SystemGameInit : BaseSystem, IInitializeSystem {
        public void Initialize(){
            //reset status
            _gameConstStateService.MaxEnemyCountInScene = 6;
            _gameConstStateService.TotalEnemyCountToBorn = 20;
            _gameStateService.remainCountToBorn = _gameConstStateService.TotalEnemyCountToBorn;
            _gameStateService.curEnemyCountInScene = 0;
            _gameStateService.bornTimer = 0;
            _gameStateService.bornInterval = 3;
            
            //create actors
            var startInfo = _constStateService.GameStartInfo;
            for (int i = 0; i < startInfo.UserInfos.Length; i++) {
                var entity = _actorContext.CreateEntity();
                entity.AddActorId((byte)i);
                entity.AddScore(0);
                entity.AddLife(_gameConstStateService.playerInitLifeCount);
            }
            var enttity = _actorContext.GetEntityWithActorId(0);
            
            Table_ConfigCamp.Load();
            Table_ConfigBullet.Load();
            Table_ConfigPlayer.Load();
            Table_ConfigEnemy.Load();
            Table_ConfigItem.Load();
            
            //create camps 
            var campPos = _gameConstStateService.campPos;
            _gameUnitService.CreateCamp(campPos,1001);
            
            //create Player entity
            for (int i = 0; i < startInfo.UserInfos.Length; i++) {
                var actorId = (byte)i;
                _gameUnitService.CreatePlayer(actorId,5003);
            }
            Debug.Log("SystemGameInit");
        }
    }
}
using Entitas;
using Lockstep.Math;

namespace Lockstep.Game.Systems.Game {}

namespace Lockstep.Game.Systems.Game {
    public class SystemEnemyBorn : BaseSystem, IExecuteSystem {


        public void Execute(){
            if (_gameStateService.CurEnemyCountInScene < _gameConstStateService.MaxEnemyCountInScene && _gameStateService.RemainCountToBorn > 0) {
                _gameStateService.BornTimer -= _gameStateService.DeltaTime;
                if (_gameStateService.BornTimer < 0) {
                    _gameStateService.BornTimer = _gameStateService.BornInterval;
                    _gameStateService.RemainCountToBorn--;
                    _gameStateService.CurEnemyCountInScene++;
                    //born enemy
                    var allPoints = _gameConstStateService.EnemyBornPoints;
                    var bornPointCount = allPoints.Count;
                    var idx = _randomService.Range(0, bornPointCount);
                    var bornPoint = allPoints[idx];
                    _gameUnitService.CreateEnemy(bornPoint);
                }
            }
        }
    }
}
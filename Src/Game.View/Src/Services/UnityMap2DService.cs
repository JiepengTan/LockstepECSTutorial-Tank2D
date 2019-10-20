using System.Collections.Generic;
using Lockstep.Math;
using UnityEngine;

namespace Lockstep.Game {
    [System.Serializable]
    public partial class UnityMap2DService : BaseMap2DService {
        [SerializeField] public Grid grid { get; private set; }
        public List<LVector2> enemyBornPoints { get; private set; }
        public List<LVector2> playerBornPoss { get; private set; }
        public LVector2 campPos { get; private set; }

        public override void DoStart(){
            base.DoStart();
            if (grid == null) {
                grid = GameObject.FindObjectOfType<Grid>();
            }
        }

        void OnEvent_SimulationAwake(object param){
            LoadLevel(1);
        }

        protected override void OnLoadLevel(int level, GridInfo gridInfo){
            UnityMap2DUtil.CheckLoadTileIDMap();
            var tileInfo = GetMapInfo(TilemapUtil.TileMapName_BornPos);
            var campPoss = tileInfo.GetAllTiles(TilemapUtil.TileID_Camp);
            Debug.Assert(campPoss != null && campPoss.Count == 1, "campPoss!= null&& campPoss.Count == 1");
            campPos = campPoss[0];
            enemyBornPoints = tileInfo.GetAllTiles(TilemapUtil.TileID_BornPosEnemy);
            playerBornPoss = tileInfo.GetAllTiles(TilemapUtil.TileID_BornPosHero);
            var _gameConstStateService = GetService<IGameConstStateService>();
            if (_gameConstStateService != null) {
                _gameConstStateService.mapMin = mapDataMin;
                _gameConstStateService.mapMax = mapDataMax;
                _gameConstStateService.enemyBornPoints = enemyBornPoints;
                _gameConstStateService.playerBornPoss = playerBornPoss;
                _gameConstStateService.campPos = campPos;
            }

            EventHelper.Trigger(EEvent.LevelLoadProgress, 0.5f);
            UnityMap2DUtil.BindMapView(grid, gridInfo);
            EventHelper.Trigger(EEvent.LevelLoadProgress, 1f);
            EventHelper.Trigger(EEvent.LevelLoadDone, level);
        }
    }
}
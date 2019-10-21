using System.Collections.Generic;
using Lockstep.Math;
using NetMsg.Common;

namespace Lockstep.Game {
    public partial class GameConstStateService : BaseService
        , IGameConstStateService //
    {
        public static GameConstStateService Instance { get; private set; }

        public GameConstStateService(){
            Instance = this;
        }


        public bool IsGameOver;

        public override void DoStart(){
            base.DoStart();
            PlayerInitLifeCount = 3;
            IsGameOver = false;
        }


        public void OnEvent_LevelLoadDone(object param){
            var level = (int) param;
            IsGameOver = false;
            _constStateService.CurLevel = level;
        }

        public void OnEvent_SimulationStart(object param){
            IsPlaying = true;
        }

        private void GameFalied(){
            IsGameOver = true;
            ShowMessage("Game Over!!");
        }

        private void GameWin(){
            IsGameOver = true;
            //f (CurLevel >= MAX_LEVEL_COUNT) {
            //   ShowMessage("You Win!!");
            //
            //lse {
            //   //Map2DService.Instance.LoadLevel(CurLevel + 1);
            //
        }

        void ShowMessage(string msg){ }
    }
}
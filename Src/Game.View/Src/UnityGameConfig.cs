using System.Collections.Generic;
using System.IO;
using Lockstep.ECS.Game;
using Lockstep.Util;
using UnityEngine;

namespace Lockstep.Game {
    [CreateAssetMenu(menuName = "GameConfig")]
    public partial class UnityGameConfig : UnityEngine.ScriptableObject {
        public GameConfig pureConfig;

        public static void SaveToJson(GameConfig config){
            var json = JsonUtil.ToJson(config);
            File.WriteAllText(Application.dataPath + "/Resources/Config/GameConfig.json", json);
        }
    }
}
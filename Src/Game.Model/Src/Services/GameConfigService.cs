using System;
using System.Collections.Generic;
using System.IO;
using Lockstep.ECS;
using Lockstep.Math;
using Lockstep.Serialization;
using Lockstep.Util;
using NetMsg.Common;
using UnityEngine;

namespace Lockstep.Game {                                                                      
	[System.Serializable]  
    public partial class GameConfigService : BaseService, IGameConfigService {
        [NonSerialized] private GameConfig _config;
        public LFloat DeltaTime => new LFloat(null,NetworkDefine.UPDATE_DELTATIME);
        public override void DoAwake(IServiceContainer services){
            var text = UnityEngine.Resources.Load<TextAsset>(_resService.GetAssetPath(11)).text;
            _config = JsonUtil.ToObject<GameConfig>(text);
            _constStateService.GameStartInfo = _config.ClientModeInfo;
        }
    }
}
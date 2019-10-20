using System;
using System.Collections.Generic;
using System.Reflection;
using Lockstep.Game;
using UnityEngine;

namespace Lockstep.Game {
    public class GameResourceService : GameService, IGameResourceService {
        public string pathPrefix = "Prefabs/";

        private Dictionary<int, GameObject> _id2Prefab = new Dictionary<int, GameObject>();

        public object LoadPrefab(int id){
            return _LoadPrefab(id);
        }

        GameObject _LoadPrefab(int id){
            if (_id2Prefab.TryGetValue(id, out var val)) {
                return val;
            }

            return null;
            //var config = _gameConfigService.GetEntityConfig(id);
            //if (string.IsNullOrEmpty(config.prefabPath)) return null;
            //var prefab = (GameObject) Resources.Load(pathPrefix + config.prefabPath);
            //_id2Prefab[id] = prefab;
            //PhysicService.Instance?.RigisterPrefab(id, id < 10 ? (int) EColliderLayer.Hero : (int) EColliderLayer.Enemy);
            //return prefab;
        }
    }
}
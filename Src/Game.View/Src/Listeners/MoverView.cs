using Entitas;
using Lockstep.Math;
using UnityEngine;

namespace Lockstep.Game {
    public class MoverView : MonoBehaviour, IEventListener {
        private GameEntity _entity;

        public void RegisterListeners(IEntity entity){
            _entity = entity as GameEntity;
        }

        public void UnRegisterListeners(){
            _entity = null;
        }

        private void Update(){
            if (_entity == null) return;
            transform.localPosition = _entity.pos.value.ToVector3();
            var deg = DirUtil.GetDirDeg(_entity.dir.value);
            transform.localRotation = Quaternion.Euler(0, 0, deg);
        }
    }
}
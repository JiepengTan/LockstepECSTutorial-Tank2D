using Lockstep.Collision2D;
using Lockstep.Game;
using Lockstep.Math;
using UnityEngine;
using Debug = Lockstep.Logging.Debug;

namespace Lockstep.Game {
    public class InputMono : UnityEngine.MonoBehaviour {
        private static bool IsReplay => Launcher.Instance?.IsVideoMode ?? false;
        public ushort skillId;
        public ushort deg;
        public void Update(){
            if (World.Instance != null && !IsReplay) {
                var dir = EDir.EnumCount;
                if (UnityEngine.Input.GetKey(KeyCode.W)) {
                    dir = EDir.Up;
                }
                else if (UnityEngine.Input.GetKey(KeyCode.D)) {
                    dir = EDir.Right;
                }
                else if (UnityEngine.Input.GetKey(KeyCode.S)) {
                    dir = EDir.Down;
                }
                else if (UnityEngine.Input.GetKey(KeyCode.A)) {
                    dir = EDir.Left;
                }
                skillId = (ushort)(Input.GetKey(KeyCode.Space) ? 1 :0);
                
                GameInputService.CurGameInput = new PlayerInput() {
                    skillId = skillId,
                    deg = (ushort)dir
                };
            }
        }
    }
}
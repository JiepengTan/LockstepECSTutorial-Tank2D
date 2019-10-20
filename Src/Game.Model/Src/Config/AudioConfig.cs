using System;
using Entitas;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Lockstep.Game {
    public partial class AudioConfig  {
        const ushort AudioIdAdd = 8001;
        const ushort AudioIdDead = 8002;
        const ushort AudioIdHitBrick = 8003;
        const ushort AudioIdHitIron = 8004;
        const ushort AudioIdStart = 8005;
        
        public ushort born;
        public ushort died = AudioIdDead;
        public ushort hitTank = AudioIdHitIron;
        public ushort hitBrick = AudioIdHitBrick;
        public ushort hitIron = AudioIdHitIron;
        public ushort destroyIron = AudioIdHitIron;
        public ushort destroyGrass;
        public ushort addItem = AudioIdAdd;
        public ushort bgMusic;
        public ushort startMusic = AudioIdStart;

        public void DoStart(){ }

        public AudioClip GetAudio(string relPath){
            return null;
        }

    }
}
using System;
using Lockstep.ECS.ECDefine;
using Lockstep.Game;
using Lockstep.Math;

namespace Lockstep.ECS.Game {
    //common
    public partial class Dir : IComponent {
        public EDir value;
    }



    public partial class Pos : IComponent {
        public Vector2 value;
    }

    public partial class ConfigId : IComponent {
        public int id;
    }

    public partial class Asset : IComponent {
        public ushort assetId;
    }

    //tag 
    [NoExcel]
    public partial class TagBullet : IComponent { }

    [NoExcel]
    public partial class TagTank : IComponent { }

    [NoExcel]
    public partial class TagEnemy : IComponent { }

    [NoExcel]
    public partial class TagCamp : IComponent { }

    //Input interface
    [NoExcel]
    public partial class FireRequest : IComponent { }

    [NoExcel]
    public partial class MoveRequest : IComponent {
        public EDir value;
    }

    //game logic
    //
    public partial class Collider : IComponent {
        public Vector2 size;
        public float radius;
    }

    public partial class Unit : IComponent {
        public string name;
        [NoExcel] public ECampType camp;
        public int health;
        public int damage;
        [NoExcel] public uint killerLocalId;
    }

    public partial class BornPoint : IComponent {
        public Vector2 pos;
    }

    public partial class Move : IComponent {
        public float moveSpd;
        public float maxMoveSpd;
        [NoExcel] public bool isChangedDir;
    }

    // enmey
    public partial class AI : IComponent {
        [NoExcel] public float timer;
        public float updateInterval;
        public float fireRate;
    }

    public partial class Skill : IComponent {
        public float cd;
        [NoExcel] public float cdTimer; // <=0 表示cd 冷却
        public int bulletId;
        [NoExcel] public bool isNeedFire;
    }

    //bullet
    public partial class Bullet : IComponent {
        public bool canDestoryIron = false;
        public bool canDestoryGrass = false;
        [NoExcel] public uint ownerLocalId;
    }

    [NoExcel]
    public partial class Owner : IComponent {
        public uint localId;
    }

    //item
    public partial class ItemType : IComponent {
        public EItemType type;
        [NoExcel] public byte killerActorId;
    }

    public partial class DropRate : IComponent {
        public float value;
    }
}
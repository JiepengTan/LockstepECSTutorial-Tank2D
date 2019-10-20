using System.Runtime.InteropServices;
using Lockstep.ECS.ECDefine;
using Lockstep.ECS.Game;

namespace Lockstep.Game {
    [StructLayout(LayoutKind.Sequential)]
    [NoExcel]
    public partial class ConfigUnit : IEntity {
        [KeyId] 
        public Asset asset;
        [NoExcel] public Dir dir;
        [NoExcel] public Pos pos;
        [NoExcel] public Collider collider;
    }

    [NoExcel]
    public partial class ConfigMover : ConfigUnit {
        public Unit unit;
        //public Collider collider;
        public Move move;
        //public Position position;
    }

    
    public partial class ConfigItem : ConfigUnit {
        public ItemType itemType;
    }

    public partial class ConfigCamp : ConfigUnit {
        public Unit unit;
        public TagCamp tagCamp;
    }
    [NoExcel]
    public partial class ConfigTank : ConfigMover {
        public Skill skill;
        public TagTank tagTank;
    }

    public partial class ConfigPlayer : ConfigTank {
        ActorId actorId;
    }

    public partial class ConfigEnemy : ConfigTank {
        public AI aI;
        public TagEnemy tagEnemy;
        public MoveRequest moveReqssuest;
        public DropRate dropRate;
    }

    public partial class ConfigBullet : ConfigMover {
        public Owner owner;
        public Bullet bullet;
        public TagBullet tagBullet;
    }
}
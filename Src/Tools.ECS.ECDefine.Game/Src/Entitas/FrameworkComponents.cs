using System;
using Lockstep.ECS.ECDefine;
using Lockstep.Game;


namespace Lockstep.ECS.Actor {
    //An ActorEntity with BackupComponent refers to an actor in the past
    public partial class Backup: IComponent {
        public byte actorId;
        public int tick;
    }
    
    /// 标志 当前Entity 是当前Tick 中存在  非Backup
    public partial class ActorId: IComponent {
        [ECDefine.Attribute(ECSNameSpaceDefine.PrimaryEntityIndex)] public byte value;
    }
    
    public partial class GameEntityId: IComponent {
        public uint value;
    }
}


namespace Lockstep.ECS.Debugging {
    public partial class HashCode: IComponent {
        public int value;
    }

    
    public partial class Tick: IComponent {
        public uint value;
    }
}


namespace Lockstep.ECS.Game {

    /// 标志 当前Entity 是当前Tick 中存在 非Backup
    public partial class EntityId: IComponent {
        [ECDefine.Attribute(ECSNameSpaceDefine.PrimaryEntityIndex)]
        public uint value;
    }
    //A GameEntity with BackupComponent refers to an entity in the past
    public partial class Backup: IComponent {
        public uint entityId;
        public int tick;
    }

    public partial class ActorId: IComponent {
        public byte value;
    }

    public partial class Destroyed: IComponent { }
    
    public partial class DelayCall: IComponent {
        public float delayTimer;
        public int callBackId;
    }
}


namespace Lockstep.ECS.GameState {

    [ECDefine.Attribute(ECSNameSpaceDefine.Unique)]
    public partial class BackupCurFrame: IComponent {}
 
    [ECDefine.Attribute(ECSNameSpaceDefine.Unique)]
    public partial class HashCode: IComponent {
        public int value;
    }
    
    [ECDefine.Attribute(ECSNameSpaceDefine.Unique)]
    public partial class Tick: IComponent {
        public int value;
    }
}
namespace Lockstep.ECS.Input {
    public partial class ActorId: IComponent {public byte value;}
    public partial class Destroyed: IComponent { }
    public partial class Tick: IComponent {public int value;}

}

namespace Lockstep.ECS.Snapshot {
    public partial class HashCode: IComponent {
        public int value;
    }
    
    public partial class Tick: IComponent {
        [ECDefine.Attribute(ECSNameSpaceDefine.PrimaryEntityIndex)] public int value;
    }
}

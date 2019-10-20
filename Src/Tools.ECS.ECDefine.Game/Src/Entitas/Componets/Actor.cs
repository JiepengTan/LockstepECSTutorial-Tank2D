using System;
using Lockstep.ECS.ECDefine;
using Lockstep.Game;



namespace Lockstep.ECS.Actor {

    [ECDefine.Attribute(ECSNameSpaceDefine.EventTargetSelf)]
    public partial class Life: IComponent {
        public int value;
    }

    [ECDefine.Attribute(ECSNameSpaceDefine.EventTargetSelf)]
    public partial class Score: IComponent {
        public int value;
    }
}

//------------------------------------------------------------------------------    
// <auto-generated>                                                                 
//     This code was generated by Tools.ECSGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null. 
//     https://github.com/JiepengTan/LockstepEngine                                          
//     Changes to this file may cause incorrect behavior and will be lost if        
//     the code is regenerated.                                                     
// </auto-generated>                                                                
//------------------------------------------------------------------------------  

using Entitas.CodeGeneration.Attributes;                                            
using Lockstep.Math;                                                                
using Entitas;                                                                      
using System;                                                                       
using Lockstep.Serialization; 

namespace Lockstep.ECS.GameState{
    [Unique]
    [GameState]
    public partial class BackupCurFrameComponent :Entitas.IComponent {
    }

    [Unique]
    [GameState]
    public partial class HashCodeComponent :Entitas.IComponent {
        public int value;
    }

    [Unique]
    [GameState]
    public partial class TickComponent :Entitas.IComponent {
        public int value;
    }

}

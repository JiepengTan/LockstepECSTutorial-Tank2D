
//------------------------------------------------------------------------------    
// <auto-generated>                                                                 
//     This code was generated by Tools.ECS2Excel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null. 
//     https://github.com/JiepengTan/LockstepEngine                                          
//     Changes to this file may cause incorrect behavior and will be lost if        
//     the code is regenerated.                                                     
// </auto-generated>                                                                
//------------------------------------------------------------------------------  
using System;
using System.Collections.Generic;
using Lockstep.Serialization;
using Lockstep.Math;
using Entitas;

namespace Lockstep.Game{
    public partial class EntityUtil{
        private static GameEntity CreateEntityEnemy(GameContext context){
            var entity = context.CreateEntity();
            AddComponent<Lockstep.ECS.Game.AIComponent>(entity,GameComponentsLookup.AI);
            AddComponent<Lockstep.ECS.Game.TagEnemyComponent>(entity,GameComponentsLookup.TagEnemy);
            AddComponent<Lockstep.ECS.Game.MoveRequestComponent>(entity,GameComponentsLookup.MoveRequest);
            AddComponent<Lockstep.ECS.Game.DropRateComponent>(entity,GameComponentsLookup.DropRate);
            AddComponent<Lockstep.ECS.Game.SkillComponent>(entity,GameComponentsLookup.Skill);
            AddComponent<Lockstep.ECS.Game.TagTankComponent>(entity,GameComponentsLookup.TagTank);
            AddComponent<Lockstep.ECS.Game.UnitComponent>(entity,GameComponentsLookup.Unit);
            AddComponent<Lockstep.ECS.Game.MoveComponent>(entity,GameComponentsLookup.Move);
            AddComponent<Lockstep.ECS.Game.AssetComponent>(entity,GameComponentsLookup.Asset);
            AddComponent<Lockstep.ECS.Game.DirComponent>(entity,GameComponentsLookup.Dir);
            AddComponent<Lockstep.ECS.Game.PosComponent>(entity,GameComponentsLookup.Pos);
            AddComponent<Lockstep.ECS.Game.ColliderComponent>(entity,GameComponentsLookup.Collider);
            return entity;
        }
        public static GameEntity CreateEntityEnemy(GameContext context, ushort prefabId){
            var entity = CreateEntityEnemy(context);
            var tblData = Table_ConfigEnemy.GetData(prefabId);
            tblData.AssignToEntity(entity);
            return entity; 
        }
    }
    public partial class Table_ConfigEnemy :IAssignToEntity
    {
        public void AssignToEntity(object entityObj){ 
            var entity = (GameEntity)entityObj;
            entity.asset.assetId = asset;
            entity.aI.updateInterval = aI_updateInterval;
            entity.aI.fireRate = aI_fireRate;
            entity.dropRate.value = dropRate;
            entity.skill.cd = skill_cd;
            entity.skill.bulletId = skill_bulletId;
            entity.unit.name = unit_name;
            entity.unit.health = unit_health;
            entity.unit.damage = unit_damage;
            entity.move.moveSpd = move_moveSpd;
            entity.move.maxMoveSpd = move_maxMoveSpd;
        }
    }
}
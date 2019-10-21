using System;
using Entitas;
using Lockstep.Math;

namespace Lockstep.Game {
    public interface IGameUnitService : IService {
        void CreateEnemy(LVector2 pos);
        void CreateEnemy(LVector2 pos, ushort type);
        void CreateBullet(LVector2 pos, EDir dir, ushort type, IEntity owner);
        void CreateCamp(LVector2 pos, ushort type);
        void CreatePlayer(byte actorId, ushort type);
        void DropItem(LFloat rate);
        void TakeDamage(IEntity bullet, IEntity suffer);
        void DelayCall(LFloat delay, Action callback);
        void Upgrade(IEntity entity);
    }

}
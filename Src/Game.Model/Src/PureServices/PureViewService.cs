
using Lockstep.Math;

namespace Lockstep.Game {
    public class PureViewService : PureBaseService, IViewService {
        public void BindView(object entity, ushort assetId, LVector2 createPos, int deg = 0){ }
        public void DeleteView(uint entityId){ }
        public void RebindView(object entity){ }
        public void RebindAllEntities(){ }
    }
}
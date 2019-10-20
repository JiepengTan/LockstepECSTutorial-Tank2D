namespace Lockstep.Game {
    public partial class EntityUtil {
        public static void AddComponent<T>(GameEntity entity, int index){
            var component = entity.CreateComponent(index, typeof(T));
            entity.AddComponent(index, component);
        }
    }
}
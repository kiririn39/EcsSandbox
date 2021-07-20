using Leopotam.EcsLite;

namespace Project.Src.ComponentAuthoring
{
    public interface IComponentAuthoring<out T> where T : struct
    {
        T Value { get;}
    }

    public interface IComponentAuthoring
    {
        void AddToWorld(EcsWorld world, int entity);
    }
}
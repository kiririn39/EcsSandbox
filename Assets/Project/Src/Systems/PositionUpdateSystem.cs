using Leopotam.EcsLite;
using Project.Src.Components;
using UnityEngine;

namespace Project.Src.Systems
{
    public class PositionUpdateSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld()
                .Filter<MoveComponent>()
                .Inc<GameobjectComponent>()
                .End();
            var movablesPool = systems.GetWorld().GetPool<MoveComponent>();
            var gameobjectsPool = systems.GetWorld().GetPool<GameobjectComponent>();

            foreach (int entity in filter)
            {
                ref var movable = ref movablesPool.Get(entity);
                ref var gameobject = ref gameobjectsPool.Get(entity);
                
                gameobject.GameObject.transform.position += (Vector3) movable.PositionChange;
                movablesPool.Del(entity);
            }
        }
    }
}
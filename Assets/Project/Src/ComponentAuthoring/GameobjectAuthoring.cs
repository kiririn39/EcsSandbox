using Leopotam.EcsLite;
using Project.Src.Components;
using UnityEngine;

namespace Project.Src.ComponentAuthoring
{
    public class GameobjectAuthoring : MonoBehaviour, IComponentAuthoring, IComponentAuthoring<GameobjectComponent>
    {
        public GameobjectComponent Value => new GameobjectComponent {GameObject = gameObject};

        public void AddToWorld(EcsWorld world, int entity)
        {
            if (world.GetPool<GameobjectComponent>().Has(entity))
                return;

            ref var comp = ref world.GetPool<GameobjectComponent>().Add(entity);
            comp.GameObject = gameObject;
        }
    }
}
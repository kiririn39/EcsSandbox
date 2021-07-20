using Leopotam.EcsLite;
using Project.Src.Components;
using UnityEngine;

namespace Project.Src.ComponentAuthoring
{
    public class PlayerTagAuthoring : MonoBehaviour, IComponentAuthoring, IComponentAuthoring<PlayerTagComponent>
    {
        public PlayerTagComponent Value => new PlayerTagComponent();

        public void AddToWorld(EcsWorld world, int entity)
        {
            if (world.GetPool<PlayerTagComponent>().Has(entity))
                return;

            world.GetPool<PlayerTagComponent>().Add(entity);
        }
    }
}
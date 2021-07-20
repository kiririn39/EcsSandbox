using Leopotam.EcsLite;
using Project.Src.Components;
using UnityEngine;

namespace Project.Src.ComponentAuthoring
{
    public class SpeedAuthoring : MonoBehaviour, IComponentAuthoring<SpeedComponent>, IComponentAuthoring
    {
        [SerializeField] private float speed;

        
        public SpeedComponent Value => new SpeedComponent {Speed = speed};

        public void AddToWorld(EcsWorld world, int entity)
        {
            if (world.GetPool<SpeedComponent>().Has(entity))
                return;
            
            ref var comp = ref world.GetPool<SpeedComponent>().Add(entity);
            comp.Speed = speed;
        }
    }
}
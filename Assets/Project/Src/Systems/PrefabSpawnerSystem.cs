using Leopotam.EcsLite;
using Project.Src.ComponentAuthoring;
using Project.Src.Interfaces;
using UnityEngine;

namespace Project.Src.Systems
{
    public class PrefabSpawnerSystem : IEcsRunSystem
    {
        private IPrefabs _prefabs;


        public PrefabSpawnerSystem(IPrefabs prefabs)
        {
            _prefabs = prefabs;
        }

        public void Run(EcsSystems systems)
        {
            var prefabsContainer = _prefabs.Pop();
            var world = systems.GetWorld();

            foreach (var prefab in prefabsContainer)
            {
                var obj = Object.Instantiate(prefab);

                var auths = obj.GetComponents<IComponentAuthoring>();

                if (auths.Length > 0)
                {
                    int entity = world.NewEntity();

                    foreach (var authoring in auths)
                        authoring.AddToWorld(world, entity);
                }
            }
        }
    }
}
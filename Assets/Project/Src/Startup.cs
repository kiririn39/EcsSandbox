using Leopotam.EcsLite;
using Project.Src.Components;
using Project.Src.Interfaces;
using Project.Src.Systems;
using UnityEngine;

namespace Project.Src
{
    public class Startup : MonoBehaviour, ITime, IPlayerInput
    {
        [SerializeField] private PrefabsContainer prefabsToSpawn;

        private EcsWorld _world;
        private EcsSystems _systems;


        public float DeltaTime => Time.deltaTime;
        public Vector2 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        private void Start()
        {
            ITime time = this;
            IPlayerInput playerInput = this;
            IPrefabs prefabs = prefabsToSpawn;

            _world = new EcsWorld();
            _systems = new EcsSystems(_world)
                .Add(new PrefabSpawnerSystem(prefabs))
                .Add(new PlayerInputSystem(playerInput))
                .Add(new MoveSystem(time))
                .Add(new PositionUpdateSystem())
                .DelHere<MoveComponent>()
                .DelHere<PositionInputComponent>();
            _systems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}
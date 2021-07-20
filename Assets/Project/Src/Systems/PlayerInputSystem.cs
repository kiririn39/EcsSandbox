using Leopotam.EcsLite;
using Project.Src.Components;
using Project.Src.Interfaces;
using UnityEngine;

namespace Project.Src.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private IPlayerInput _playerInput;

        public PlayerInputSystem(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld()
                .Filter<PlayerTagComponent>()
                .Inc<SpeedComponent>()
                .End();
            var posInputPool = systems.GetWorld().GetPool<PositionInputComponent>();
            Vector2 moveInput = _playerInput.MoveInput;

            foreach (int entity in filter)
            {
                if (posInputPool.Has(entity))
                    continue;
                
                ref var posInput = ref posInputPool.Add(entity);
                posInput.Input = moveInput;
            }
        }
    }
}
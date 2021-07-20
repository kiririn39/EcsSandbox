using Leopotam.EcsLite;
using Project.Src.Components;
using Project.Src.Interfaces;
using UnityEngine;

namespace Project.Src.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private ITime _time;

        public MoveSystem(ITime time)
        {
            _time = time;
        }

        public void Run(EcsSystems systems)
        {
            var filter = systems.GetWorld()
                .Filter<SpeedComponent>()
                .Inc<PositionInputComponent>()
                .End();
            var speedPool = systems.GetWorld().GetPool<SpeedComponent>();
            var inputPool = systems.GetWorld().GetPool<PositionInputComponent>();
            var movePool = systems.GetWorld().GetPool<MoveComponent>();
            var deltaTime = _time.DeltaTime;

            foreach (int entity in filter)
            {
                if (movePool.Has(entity))
                    continue;

                ref var speedComp = ref speedPool.Get(entity);
                ref var inputComp = ref inputPool.Get(entity);

                Vector2 positionChange = speedComp.Speed * inputComp.Input * deltaTime;

                ref var move = ref movePool.Add(entity);
                move.PositionChange = positionChange;

                inputPool.Del(entity);
            }
        }
    }
}
using Leopotam.Ecs;
using UnityEngine;

namespace Player
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerMovableComponent, PlayerTag> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                var currentPosition = movableFilter.Get2(i).gameObject.transform.position;
                currentPosition.x = movableFilter.Get1(i).offset * 2;

                currentPosition.z += movableFilter.Get1(i).speed * Time.deltaTime;
                movableFilter.Get2(i).gameObject.transform.position = currentPosition;
            }
        }
    }
}

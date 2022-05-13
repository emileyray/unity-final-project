using Leopotam.Ecs;
using Player;
using UnityEngine;

namespace PickableCube
{
    internal sealed class CubePuttingInStackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _movableFilter = null;
        private readonly EcsFilter<PickableCubeTag> _pickableCubeFilter = null;

        public void Run()
        {
            ref var playerTag = ref _movableFilter.Get1(0);
            foreach (var i in _pickableCubeFilter)
            {
                ref var pickableCubeTag = ref _pickableCubeFilter.Get1(i);
                if (!pickableCubeTag.isPicked || pickableCubeTag.isInStack) continue;
                
                foreach (var j in _pickableCubeFilter)
                {
                    ref var anotherPickableCubeTag = ref _pickableCubeFilter.Get1(j);
                    if (!anotherPickableCubeTag.isInStack || anotherPickableCubeTag.isLost) continue;
                        
                    var anotherCubePosition = anotherPickableCubeTag.gameObject.transform.position;
                    anotherCubePosition.y += 0.75f;
                    anotherPickableCubeTag.gameObject.transform.position = anotherCubePosition;
                }
                    
                var initPlayerPosition = playerTag.gameObject.transform.position;
                var playerPosition = initPlayerPosition;
                playerPosition.y += 0.75f;
                playerTag.gameObject.transform.position = playerPosition;
                    
                var cubePosition = initPlayerPosition;
                cubePosition.y = 1.9f;
                pickableCubeTag.gameObject.transform.position = cubePosition;

                pickableCubeTag.isInStack = true;
            }
        }
    }
}
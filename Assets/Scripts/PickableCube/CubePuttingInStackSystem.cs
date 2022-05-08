using Leopotam.Ecs;
using Player;
using UnityEngine;

namespace PickableCube
{
    public class CubePuttingInStackSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag> movableFilter = null;
        private readonly EcsFilter<PickableCubeTag> pickableCubeFilter = null;

        public void Run()
        {
            ref var playerTag = ref movableFilter.Get1(0);
            foreach (var i in pickableCubeFilter)
            {
                ref var pickableCubeTag = ref pickableCubeFilter.Get1(i);
                if (pickableCubeTag.isPicked && !pickableCubeTag.isInStack)
                {
                    foreach (var j in pickableCubeFilter)
                    {
                        ref var anotherPickableCubeTag = ref pickableCubeFilter.Get1(j);
                        if (anotherPickableCubeTag.isInStack && !anotherPickableCubeTag.isLost)
                        {
                            var anotherCubePosition = anotherPickableCubeTag.gameObject.transform.position;
                            anotherCubePosition.y += 0.75f;
                            anotherPickableCubeTag.gameObject.transform.position = anotherCubePosition;
                        }
                    }
                    
                    var playerPosition = playerTag.gameObject.transform.position;
                    playerPosition.y += 0.75f;
                    playerTag.gameObject.transform.position = playerPosition;
                    
                    var cubePosition = playerTag.gameObject.transform.position;
                    cubePosition.y = 1.9f;
                    pickableCubeTag.gameObject.transform.position = cubePosition;

                    pickableCubeTag.isInStack = true;
                }
            }
        }
    }
}
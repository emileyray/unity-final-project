using Leopotam.Ecs;
using PickableCube;
using UnityEngine;

namespace Player
{
    sealed class CubePickingSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag> movableFilter = null;
        private readonly EcsFilter<PickableCubeTag> pickableCubeFilter = null;

        public void Run()
        {
            ref var playerTag = ref movableFilter.Get1(0);
            foreach (var i in pickableCubeFilter)
            {
                if (pickableCubeFilter.Get1(i).isLost)
                {
                    continue;
                }
                
                BoxCollider cubeCollider = pickableCubeFilter.Get1(i).gameObject.GetComponent<BoxCollider>();
                if (pickableCubeFilter.Get1(i).isLost)
                {
                    continue;
                }
                foreach (var playerCollider in playerTag.gameObject.GetComponents<Collider>())
                {
                    if (playerCollider.bounds.Intersects(cubeCollider.bounds))
                    {
                        pickableCubeFilter.Get1(i).isPicked = true;
                        continue;
                    }
                    
                }
                
                foreach (var j in pickableCubeFilter)
                {
                    ref var anotherCubeTag = ref pickableCubeFilter.Get1(j);
                    
                    
                    if (pickableCubeFilter.Get1(j).isLost)
                    {
                        continue;
                    }
                    
                    BoxCollider anotherCubeCollider = anotherCubeTag.gameObject.GetComponent<BoxCollider>();
                    
                    if (anotherCubeCollider.bounds.Intersects(cubeCollider.bounds) && anotherCubeTag.isInStack)
                    {
                        pickableCubeFilter.Get1(i).isPicked = true;
                    }
                }
            }
        }
    }
}
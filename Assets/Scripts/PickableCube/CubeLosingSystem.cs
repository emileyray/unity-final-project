using Leopotam.Ecs;
using StaticCube;
using UnityEngine;

namespace PickableCube
{
    sealed class CubeLosingSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PickableCubeTag> pickableCubeFilter = null;
        private readonly EcsFilter<StaticCubeTag> staticCubeFilter = null;

        public void Run()
        {
            foreach (var i in pickableCubeFilter)
            {
                if (pickableCubeFilter.Get1(i).isLost)
                {
                    continue;
                }
                
                BoxCollider pickableCubeCollider = pickableCubeFilter.Get1(i).loseTrigger.GetComponent<BoxCollider>();

                foreach (var j in staticCubeFilter)
                {
                    BoxCollider staticCubeCollider = staticCubeFilter.Get1(j).gameObject.GetComponent<BoxCollider>();

                    if (pickableCubeCollider.bounds.Intersects(staticCubeCollider.bounds))
                    {
                        pickableCubeFilter.Get1(i).isLost = true;
                    }
                }
            }
        }
    }
}
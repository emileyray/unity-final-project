using Leopotam.Ecs;
using StaticCube;
using UnityEngine;
using Lava;

namespace PickableCube
{
    internal sealed class CubeLosingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PickableCubeTag> _pickableCubeFilter = null;
        private readonly EcsFilter<StaticCubeTag> _staticCubeFilter = null;
        private readonly EcsFilter<LavaTag> _lavaFilter = null;

        public void Run()
        {
            foreach (var i in _pickableCubeFilter)
            {
                if (_pickableCubeFilter.Get1(i).isLost) continue;
                
                CheckCollisionWithStaticCube(i);
                CheckCollisionWithLava(i);
            }

            void CheckCollisionWithStaticCube(int i)
            {
                var pickableCubeTriggerCollider 
                    = _pickableCubeFilter.Get1(i).loseTrigger.GetComponent<BoxCollider>();

                foreach (var j in _staticCubeFilter)
                {
                    var staticCubeCollider = _staticCubeFilter.Get1(j).gameObject.GetComponent<BoxCollider>();

                    if (pickableCubeTriggerCollider.bounds.Intersects(staticCubeCollider.bounds))
                    {
                        _pickableCubeFilter.Get1(i).isLost = true;
                    }
                }
            }

            void CheckCollisionWithLava(int i)
            {
                var pickableCubeCollider 
                    = _pickableCubeFilter.Get1(i).gameObject.GetComponent<BoxCollider>();
                
                foreach (var j in _lavaFilter)
                {
                    var lavaTrigger = _lavaFilter.Get1(j).lavaTrigger.GetComponent<MeshCollider>();

                    if (pickableCubeCollider.bounds.Intersects(lavaTrigger.bounds))
                    {
                        _pickableCubeFilter.Get1(i).isLost = true;
                    }
                }
            }
        }
    }
}
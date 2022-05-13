using Leopotam.Ecs;
using PickableCube;
using UnityEngine;

namespace Player
{
    internal sealed class CubePickingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _movableFilter = null;
        private readonly EcsFilter<PickableCubeTag> _pickableCubeFilter = null;

        public void Run()
        {
            ref var playerTag = ref _movableFilter.Get1(0);
            foreach (var i in _pickableCubeFilter)
            {
                if (_pickableCubeFilter.Get1(i).isLost) continue;
                
                var cubeCollider = _pickableCubeFilter.Get1(i).gameObject.GetComponent<BoxCollider>();
                if (_pickableCubeFilter.Get1(i).isLost) continue;
                
                foreach (var playerCollider in playerTag.gameObject.GetComponents<Collider>())
                {
                    if (playerCollider.bounds.Intersects(cubeCollider.bounds))
                    {
                        _pickableCubeFilter.Get1(i).isPicked = true;
                    }
                }
                
                foreach (var j in _pickableCubeFilter)
                {
                    ref var anotherCubeTag = ref _pickableCubeFilter.Get1(j);
                    if (_pickableCubeFilter.Get1(j).isLost) continue;
                    
                    var anotherCubeCollider = anotherCubeTag.gameObject.GetComponent<BoxCollider>();
                    
                    if (anotherCubeCollider.bounds.Intersects(cubeCollider.bounds) && anotherCubeTag.isInStack)
                    {
                        _pickableCubeFilter.Get1(i).isPicked = true;
                    }
                }
            }
        }
    }
}
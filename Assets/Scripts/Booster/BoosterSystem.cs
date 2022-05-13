using Leopotam.Ecs;
using PickableCube;
using UnityEngine;

namespace Booster
{
    public class BoosterSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PickableCubeTag> _pickableCubeFilter = null;
        private readonly EcsFilter<BoosterTag> _boosterFilter = null;

        public void Run()
        {
            foreach (var i in _pickableCubeFilter)
            {
                if (!_pickableCubeFilter.Get1(i).isInStack || _pickableCubeFilter.Get1(i).isLost)
                {
                    continue;
                }
                
                var pickableCubeCollider = _pickableCubeFilter.Get1(i).gameObject.GetComponent<BoxCollider>();

                foreach (var j in _boosterFilter)
                {
                    var boosterCollider = _boosterFilter.Get1(j).gameObject.GetComponent<BoxCollider>();

                    if (_boosterFilter.Get1(j).isTriggered)
                    {
                        continue;
                    }
                    
                    if (boosterCollider.bounds.Intersects(pickableCubeCollider.bounds))
                    {
                        _boosterFilter.Get1(j).isTriggered = true;
                        _pickableCubeFilter.Get1(i).isLost = true;
                        _pickableCubeFilter.Get1(i).cubeBehaviour.Destroy();
                    }
                }
            }
        }
    }
}
using Leopotam.Ecs;
using PickableCube;
using Player;
using StaticCube;
using UnityEngine;

namespace Booster
{
    public class BoosterSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PickableCubeTag> pickableCubeFilter = null;
        private readonly EcsFilter<BoosterTag> boosterFilter = null;
        private readonly EcsFilter<PlayerTag> playerFilter = null;
        
        public void Run()
        {
            foreach (var i in pickableCubeFilter)
            {
                ref var playerTag = ref playerFilter.Get1(0);
                
                if (!pickableCubeFilter.Get1(i).isInStack || pickableCubeFilter.Get1(i).isLost)
                {
                    continue;
                }
                BoxCollider pickableCubeCollider = pickableCubeFilter.Get1(i).gameObject.GetComponent<BoxCollider>();

                foreach (var j in boosterFilter)
                {
                    BoxCollider boosterCollider = boosterFilter.Get1(j).gameObject.GetComponent<BoxCollider>();

                    if (boosterFilter.Get1(j).isTriggered)
                    {
                        continue;
                    }
                    
                    if (boosterCollider.bounds.Intersects(pickableCubeCollider.bounds))
                    {
                        Debug.Log("lol");
                        boosterFilter.Get1(j).isTriggered = true;
                        pickableCubeFilter.Get1(i).isLost = true;
                        pickableCubeFilter.Get1(i).cubeBehaviour.Destroy();
                    }
                }
            }
        }
    }
}
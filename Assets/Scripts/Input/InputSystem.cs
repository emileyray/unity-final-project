using Leopotam.Ecs;
using UnityEngine;
using Player;

namespace Input
{
    sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        
        private readonly EcsFilter<PlayerMovableComponent> movableFilter = null;
        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var movableComponent = ref movableFilter.Get1(i);

                if (UnityEngine.Input.touchCount > 0)
                {
                    Touch touch = UnityEngine.Input.GetTouch(0);
                    float x = touch.position.x;
                    movableComponent.offset =
                        ConvertToOffsetRatio(x);
                }
                
                if (UnityEngine.Input.GetMouseButton(0)){
                    movableComponent.offset =
                                            ConvertToOffsetRatio(UnityEngine.Input.mousePosition.x);
                }
            }
        }

        float ConvertToOffsetRatio(float x)
        {
            float inputtableRatio = 0.6f;
            float width = Screen.width;
            if (x < width * (1 - inputtableRatio) / 2)
            {
                return -0.5f;
            } 
            if (x > width * inputtableRatio + width * (1 - inputtableRatio) / 2)
            {
                return 0.5f;
            }
            
            return (x - width * (1 - inputtableRatio) / 2 - width * inputtableRatio / 2) /
                   (width - width * (1 - inputtableRatio));
        }
    }
}
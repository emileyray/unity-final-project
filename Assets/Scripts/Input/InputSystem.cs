using Leopotam.Ecs;
using UnityEngine;
using Player;

namespace Input
{
    internal sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerMovableComponent> _movableFilter = null;
        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(i);
                
                if (UnityEngine.Input.GetMouseButton(0)){
                    movableComponent.offset =
                                            ConvertToOffsetRatio(UnityEngine.Input.mousePosition.x);
                }
            }
        }

        private static float ConvertToOffsetRatio(float x)
        {
            var inputtableRatio = 0.6f;
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
using Leopotam.Ecs;
using Player;

namespace PickableCube
{
    internal sealed class CubeFollowingPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _movableFilter = null;
        private readonly EcsFilter<PickableCubeTag> _pickableCubeFilter = null;

        public void Run()
        {
            ref var playerTag = ref _movableFilter.Get1(0);
            var playerPosition = playerTag.gameObject.transform.position;
            foreach (var i in _pickableCubeFilter)
            {
                ref var pickableCubeTag = ref _pickableCubeFilter.Get1(i);
                if (pickableCubeTag.isLost || !pickableCubeTag.isInStack)  continue;
                
                var cubePosition = pickableCubeTag.gameObject.transform.position;
                cubePosition.x = playerPosition.x;
                cubePosition.z = playerPosition.z;
                pickableCubeTag.gameObject.transform.position = cubePosition;
            }
        }
    }
}
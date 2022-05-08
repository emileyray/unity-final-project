using Leopotam.Ecs;
using Player;

namespace PickableCube
{
    sealed class CubeFollowingPlayerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag> movableFilter = null;
        private readonly EcsFilter<PickableCubeTag> pickableCubeFilter = null;

        public void Run()
        {
            ref var playerTag = ref movableFilter.Get1(0);
            var playerPosition = playerTag.gameObject.transform.position;
            foreach (var i in pickableCubeFilter)
            {
                ref var pickableCubeTag = ref pickableCubeFilter.Get1(i);
                if (pickableCubeTag.isLost)
                {
                    continue;
                }
                if (pickableCubeTag.isInStack)
                {
                    var cubePosition = pickableCubeTag.gameObject.transform.position;
                    cubePosition.x = playerPosition.x;
                    cubePosition.z = playerPosition.z;
                    pickableCubeTag.gameObject.transform.position = cubePosition;
                }
            }
        }
    }
}
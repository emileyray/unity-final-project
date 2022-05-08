using Cinemachine;
using Leopotam.Ecs;
using PickableCube;
using UnityEngine;

namespace Camera
{
    public class CameraSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CameraTag> cameraFilter = null;
        private readonly EcsFilter<PickableCubeTag> cubeFilter = null;

        public void Run()
        {
            foreach (var i in cameraFilter)
            {
                var camera = cameraFilter.Get1(i).camera;
                var cubeCount = 0f;

                foreach (var j in cubeFilter)
                {
                    if (cubeFilter.Get1(j).isInStack && !cubeFilter.Get1(j).isLost)
                    {
                        cubeCount += 1.5f;
                    }
                }
                
                var nextFov = cubeCount + 60;
                camera.m_Lens.FieldOfView = Mathf.Lerp(camera.m_Lens.FieldOfView, nextFov, 0.15f);
            }
        }
    }
}
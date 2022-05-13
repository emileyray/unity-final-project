using Cinemachine;
using Leopotam.Ecs;
using PickableCube;
using UnityEngine;
using Player;
using UnityEngine.Animations;

namespace PlayerCamera
{
    public class CameraSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraTag> _cameraFilter = null;
        private readonly EcsFilter<PlayerTag> _playerFilter = null;
            
        private readonly EcsFilter<PickableCubeTag> _cubeFilter = null;

        public void Run()
        {
            _cameraFilter.Get1(0).camera.Follow = _playerFilter.Get1(0).gameObject.transform;
            foreach (var i in _cameraFilter)
            {
                var camera = _cameraFilter.Get1(i).camera;
                var cubeCount = 0f;

                foreach (var j in _cubeFilter)
                {
                    if (_cubeFilter.Get1(j).isInStack && !_cubeFilter.Get1(j).isLost)
                    {
                        cubeCount += 1.5f;
                    }
                }
                
                var nextFov = cubeCount/2 + 60;
                camera.m_Lens.FieldOfView = Mathf.Lerp(camera.m_Lens.FieldOfView, nextFov, 0.05f);
                
                var transposer = camera.GetCinemachineComponent<CinemachineTransposer>();
                transposer.m_FollowOffset = Vector3.Lerp(
                    transposer.m_FollowOffset, 
                    new Vector3(1, 4.5f - cubeCount/4, -6),
                    0.05f);
                
                var comp = camera.GetCinemachineComponent<CinemachineComposer>();
                var nextOffset = comp.m_TrackedObjectOffset;
                nextOffset.y = 1 - cubeCount/5;
                comp.m_TrackedObjectOffset = Vector3.Lerp(
                    comp.m_TrackedObjectOffset, 
                    nextOffset,
                    0.05f);
            }
        }
    }
}
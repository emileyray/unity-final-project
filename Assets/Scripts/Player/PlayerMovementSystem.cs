using System.Runtime.CompilerServices;
using Leopotam.Ecs;
using StartGame;
using UnityEngine;

namespace Player
{
    internal sealed class MovementSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<PlayerMovableComponent, PlayerTag> _movableFilter = null;
        private readonly EcsFilter<StartGameTag> _startGameFilter = null;

        public void Init()
        {
            _movableFilter.Get1(0).speed = 8;
        }
        
        public void Run()
        {
            if (!_startGameFilter.Get1(0).started) return;
            
            foreach (var i in _movableFilter)
            {
                var currentPosition = _movableFilter.Get2(i).turnableWrapper.transform.position;
                currentPosition += 
                    _movableFilter.Get1(i).speed * Time.deltaTime * 
                    _movableFilter.Get2(i).turnableWrapper.transform.forward;
                
                var currentLocalPosition = _movableFilter.Get2(i).gameObject.transform.localPosition;
                currentLocalPosition.x = _movableFilter.Get1(i).offset * 3f;
                _movableFilter.Get2(i).turnableWrapper.transform.position = currentPosition;
                _movableFilter.Get2(i).gameObject.transform.localPosition = currentLocalPosition;

            }
        }
    }
}

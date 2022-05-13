using StaticCube;
using Leopotam.Ecs;
using Player;
using UnityEngine;
using Lava;

namespace Lose
{
    internal sealed class LoseDetectingSystem : IEcsRunSystem
    {
	    private readonly EcsFilter<PlayerMovableComponent, PlayerTag> _playerFilter = null;
        private readonly EcsFilter<StaticCubeTag> _staticCubeFilter = null;
		private readonly EcsFilter<LavaTag> _lavaFilter = null;
        private readonly GameUI _gameUI = null;

        public void Run()
        {
	        ref var playerEntity = ref _playerFilter.GetEntity(0);
	        ref var playerTag = ref playerEntity.Get<PlayerTag>();
            var playerTriggerCollider = playerTag.loseTrigger.GetComponent<BoxCollider>();
            
            foreach (var i in _staticCubeFilter)
            {
                var staticCubeCollider = _staticCubeFilter.Get1(i).gameObject.GetComponent<BoxCollider>();

                if (!staticCubeCollider.bounds.Intersects(playerTriggerCollider.bounds)) continue;
                
                _gameUI.loseCanvas.SetActive(true);
                _playerFilter.Get1(0).speed = 0;
                playerEntity.Del<PlayerMovableComponent>();
            }

			foreach (var j in _lavaFilter)
            {
                var lavaTrigger = _lavaFilter.Get1(j).lavaTrigger.GetComponent<MeshCollider>();

                foreach (var playerCollider in playerTag.gameObject.GetComponents<Collider>())
                {
	                if (!playerCollider.bounds.Intersects(lavaTrigger.bounds)) continue;
	                
	                _gameUI.loseCanvas.SetActive(true);
	                _playerFilter.Get1(0).speed = 0;
	                playerEntity.Del<PlayerMovableComponent>();
	                Time.timeScale=0;
                }	
            }
        }
    }
}

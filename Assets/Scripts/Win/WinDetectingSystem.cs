using Booster;
using Leopotam.Ecs;
using PickableCube;
using Player;
using UnityEngine;

namespace Win
{
    sealed class WinDetectingSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerMovableComponent, PlayerTag> movableFilter = null;
        private readonly EcsFilter<BoosterTag> boosterFilter = null;
        private GameUI _gameUI = null;

        public void Run()
        {
            ref var playerEntity = ref movableFilter.GetEntity(0);
            ref var playerTag = ref playerEntity.Get<PlayerTag>();
            foreach (var i in boosterFilter)
            {
                BoxCollider boosterCollider = boosterFilter.Get1(i).gameObject.GetComponent<BoxCollider>();

                foreach (var playerCollider in playerTag.gameObject.GetComponents<Collider>())
                {
                    if (playerCollider.bounds.Intersects(boosterCollider.bounds))
                    {
                        _gameUI.winCanvas.SetActive(true);
                        _gameUI.winCanvas.GetComponent<WinCanvas>().SetBooster(boosterFilter.Get1(i).boost);
                        movableFilter.Get1(0).speed = 0;
                        playerEntity.Del<PlayerMovableComponent>();
                    }
                }
            }
        }
    }
}
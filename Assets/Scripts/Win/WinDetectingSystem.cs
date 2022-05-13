using Booster;
using Leopotam.Ecs;
using PickableCube;
using Player;
using UnityEngine;

namespace Win
{
    internal sealed class WinDetectingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerMovableComponent, PlayerTag> _movableFilter = null;
        private readonly EcsFilter<BoosterTag> _boosterFilter = null;
        private readonly GameUI _gameUI = null;

        public void Run()
        {
            ref var playerEntity = ref _movableFilter.GetEntity(0);
            ref var playerTag = ref playerEntity.Get<PlayerTag>();
            foreach (var j in _movableFilter)
            {
                foreach (var i in _boosterFilter)
                {
                    BoxCollider boosterCollider = _boosterFilter.Get1(i).gameObject.GetComponent<BoxCollider>();

                    foreach (var playerCollider in playerTag.gameObject.GetComponents<Collider>())
                    {
                        if (playerCollider.bounds.Intersects(boosterCollider.bounds))
                        {
                            _gameUI.winCanvas.SetActive(true);
                            _gameUI.winCanvas.GetComponent<WinCanvas>().SetBooster(_boosterFilter.Get1(i).boost);
                            _movableFilter.Get1(0).speed = 0;
                            playerEntity.Del<PlayerMovableComponent>();

                            int currentLevel = PlayerPrefs.GetInt("level");
                            int currentScore = PlayerPrefs.GetInt("score");
                            PlayerPrefs.SetInt("level", currentLevel + 1);
                            PlayerPrefs.SetInt("score", currentScore + _boosterFilter.Get1(i).boost * 20);
                            PlayerPrefs.Save();
                        }
                    }
                }
            }
        }
    }
}
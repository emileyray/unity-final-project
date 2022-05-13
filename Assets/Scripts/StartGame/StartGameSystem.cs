using Leopotam.Ecs;

namespace StartGame
{
    public class StartGameSystem : IEcsInitSystem
    {
        private readonly EcsFilter<StartGameTag> _startGameFilter = null;

        public void Init()
        {
            _startGameFilter.Get1(0).startGameButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _startGameFilter.Get1(0).started = true;
            _startGameFilter.Get1(0).startGameCanvas.SetActive(false);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace StartGame
{
    [Serializable]
    public struct StartGameTag
    {
        public Button startGameButton;
        public GameObject startGameCanvas;
        public bool started;
    }
}
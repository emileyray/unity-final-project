using System;
using TMPro;
using UnityEngine;

namespace Win
{
    public class WinCanvas : MonoBehaviour
    {
        public TextMeshProUGUI multiplierText;
        public TextMeshProUGUI scoreText;

        public void SetBooster(int value)
        {
            multiplierText.text = value + "x";
            scoreText.text = (value * 20).ToString();
        }
    }
}
    
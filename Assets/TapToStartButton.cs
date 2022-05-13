using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartButton : MonoBehaviour
{
    public Button Button;
    public GameObject Canvas;
    void Start()
    {
        Time.timeScale = 0;
        Button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }
}

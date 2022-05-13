using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public GameObject prizeCanvas;

    public Button nextLevelButton;
    public Button tryAgainButton;
    
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    
    private int _currentScore;
    private int _currentLevel;
    private void Awake()
    {
        print(GameObject.Find("Prize Canvas"));
        Time.timeScale = 1;
        
        _currentScore = PlayerPrefs.GetInt("score");
        _currentLevel = PlayerPrefs.GetInt("level");
        
        if (SceneManager.GetActiveScene().buildIndex != ConvertLevel(_currentLevel))
        {
            SceneManager.LoadScene(ConvertLevel(_currentLevel));
        }
        
        nextLevelButton.onClick.AddListener(SetNextLevel);
        tryAgainButton.onClick.AddListener(RestartLevel);

        scoreText.text = _currentScore.ToString();
        levelText.text = "lvl. " + _currentLevel;
    }

    private static int ConvertLevel(int currentValue)
    {
        if (currentValue <= 5)
        {
            return currentValue - 1;
        }

        return (currentValue % 3) switch
        {
            0 => 2,
            1 => 3,
            2 => 4,
            _ => 0
        };
    }
    
    private void SetNextLevel()
    {
        var nextLevel = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene(ConvertLevel(nextLevel)); 
        GameObject.FindWithTag("Prize Canvas");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private static void RestartLevel()
    {
        var nextLevel = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene(ConvertLevel(nextLevel));
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Instantiate(prizeCanvas);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

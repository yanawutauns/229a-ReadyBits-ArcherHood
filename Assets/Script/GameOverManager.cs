using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // เพิ่มตรงนี้

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] Button restartButton;
    [SerializeField] ScoreManager scoreManager;

    void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void ShowGameOver(string result)
    {
        string finalResult = result + "\nScore: " + scoreManager.GetScore();
        resultText.text = finalResult;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}

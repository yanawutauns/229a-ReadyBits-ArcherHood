using UnityEngine;
using TMPro;  

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;  
    private int score = 0;  

    void Start()
    {
        UpdateScoreText();  
    }

    
    public void AddScore(int points)
    {
        score += points;  
        UpdateScoreText();  
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;  
    }
}

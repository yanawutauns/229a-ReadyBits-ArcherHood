using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.AddScore(1000);
        }
    }
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] ArrowUIManager arrowUIManager;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        if (PlayerWins())
        {
            gameEnded = true;
            gameOverManager.ShowGameOver("You Win!");
        }
        else if (ShouldCheckLose())
        {
            StartCoroutine(DelayedLoseCheck());
        }
    }

    bool PlayerWins()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }

    bool ShouldCheckLose()
    {
        // เมื่อธนูหมดในมือ → ให้รอเช็คว่าแพ้ไหม
        return arrowUIManager.GetRemainingArrowCount() == 0;
    }

    IEnumerator DelayedLoseCheck()
    {
        // ป้องกันไม่ให้เรียกหลายรอบ
        gameEnded = true;

        // รอ 0.5 วินาที ให้ลูกธนูสุดท้ายมีเวลาชนศัตรู
        yield return new WaitForSeconds(3.0f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");

        if (enemies.Length > 0 && arrows.Length == 0)
        {
            gameOverManager.ShowGameOver("You Lose!");
        }
        else
        {
            // ยังไม่แพ้จริง → ให้เกมดำเนินต่อ
            gameEnded = false;
        }
    }
}

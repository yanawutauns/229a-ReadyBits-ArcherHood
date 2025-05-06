using UnityEngine;
using TMPro;  // ใช้ TextMeshPro

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;  // ใช้เพื่อแสดงคะแนนใน UI (TextMeshPro)
    private int score = 0;  // คะแนนเริ่มต้น

    void Start()
    {
        UpdateScoreText();  // เริ่มต้นการแสดงคะแนน
    }

    // ฟังก์ชันสำหรับเพิ่มคะแนน
    public void AddScore(int points)
    {
        score += points;  // เพิ่มคะแนน
        UpdateScoreText();  // อัพเดต UI
    }

    // อัพเดตข้อความที่แสดงคะแนน
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;  // อัพเดตข้อความ
    }
}

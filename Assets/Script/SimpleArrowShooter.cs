using UnityEngine;

public class SimpleArrowShooter : MonoBehaviour
{
    [SerializeField] Transform shootPoint;              // จุดยิงลูกธนู
    [SerializeField] Rigidbody2D arrowPrefab;           // พรีแฟบของลูกธนู
    [SerializeField] float arrowSpeed = 10f;            // ความเร็วลูกธนู
    [SerializeField] int maxArrows = 3;                 // จำนวนลูกธนูสูงสุด
    [SerializeField] ArrowUIManager arrowUIManager;     // อ้างถึง UI ของลูกธนู

    private int arrowsLeft;

    void Start()
    {
        arrowsLeft = maxArrows;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && arrowsLeft > 0)
        {
            // ตำแหน่งของเมาส์ในโลกจริง
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            // คำนวณทิศทางการยิง
            Vector2 direction = (mouseWorldPos - shootPoint.position).normalized;

            // สร้างลูกธนู
            Rigidbody2D arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

            // หมุนลูกธนูให้หันตามทิศทาง
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle);

            // กำหนดความเร็วลูกธนู
            arrow.linearVelocity = direction * arrowSpeed;

            // หักจำนวนลูกธนูที่เหลือ
            arrowsLeft--;

            // ลบไอคอนลูกธนูใน UI
            if (arrowUIManager != null)
            {
                arrowUIManager.UseArrow();
            }
        }
    }
}

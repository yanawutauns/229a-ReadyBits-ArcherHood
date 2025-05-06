using UnityEngine;

public class SimpleArrowShooter : MonoBehaviour
{
    [SerializeField] Transform shootPoint;         
    [SerializeField] Rigidbody2D arrowPrefab;      
    [SerializeField] float arrowSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            
            Vector2 direction = (mouseWorldPos - shootPoint.position).normalized;

            
            Rigidbody2D arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle);

            
            arrow.linearVelocity = direction * arrowSpeed;
        }
    }
}

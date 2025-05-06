using UnityEngine;

public class ArmOrbitMouse : MonoBehaviour
{
    public Transform center;     
    public float radius = 0.5f;  

    void Update()
    {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        
        Vector3 direction = (mousePos - center.position).normalized;

        
        Vector3 handPosition = center.position + direction * radius;
        transform.position = handPosition;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public float lifeTime = 3f; 
    public float arrowSpeed = 10f;
    public Rigidbody2D rb; 
    public float gravityScale = 1f; 

    private Vector2 shootDirection;

    void Start()
    {
        
        rb.gravityScale = gravityScale;

        
        Destroy(gameObject, lifeTime); 

        
        shootDirection = rb.linearVelocity.normalized;
    }

    
    public void Shoot(Vector2 direction)
    {
        rb.linearVelocity = direction * arrowSpeed; 
    }

    void Update()
    {
        
        float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            
            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }
    }
}

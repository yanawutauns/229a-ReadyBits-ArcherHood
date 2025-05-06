using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 1f;           
    public float moveDistance = 2f;    

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moveStep = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.position += Vector3.right * moveStep;
            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveStep;
            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}

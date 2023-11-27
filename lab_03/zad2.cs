using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 2f;
    public float maxX = 10f;
    public float minX = -10f;

    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.Translate((Vector3.right * speed * Time.deltaTime) * (movingRight ? 1 : -1));
    }

    void CheckBounds()
    {
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            movingRight = !movingRight;
        }
    }

    private bool movingRight = true;
}
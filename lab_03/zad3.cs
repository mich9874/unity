using UnityEngine;

public class MoveCube2 : MonoBehaviour
{
    public float speed = 2f;
    public float sideLength = 10f;
    public Transform forwardElement;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        float moveDistance = speed * Time.deltaTime;
        Vector3 moveDirectionVector = forwardElement.position - transform.position;
        transform.Translate(moveDirectionVector * moveDistance, Space.World);
    }

    void CheckBounds()
    {
        if (Vector3.Distance(initialPosition, transform.position) >= sideLength)
        {
            RotateAndResetPosition();
        }
    }

    void RotateAndResetPosition()
    {
        transform.Rotate(Vector3.up, 90f);
        initialPosition = transform.position;
    }
}
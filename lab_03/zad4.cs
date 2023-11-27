using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody rb;
    public GameObject ground;

    void FixedUpdate()
    {
        Move();
        ClampPosition();
    }

    void Move()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = velocity.normalized * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + velocity;

        rb.MovePosition(newPosition);
    }

    void ClampPosition()
    {
        Vector3 groundPosition = ground.transform.position;
        Vector3 groundSize = ground.transform.localScale;

        float minX = groundPosition.x - (groundSize.x / 2f) * 10;
        float maxX = groundPosition.x + (groundSize.x / 2f) * 10;
        float minZ = groundPosition.z - (groundSize.z / 2f) * 10;
        float maxZ = groundPosition.z + (groundSize.z / 2f) * 10;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);

        rb.MovePosition(clampedPosition);
    }
}
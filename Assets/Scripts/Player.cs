using UnityEngine;
public class Player  : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    Vector2 movement;

    public KeyCode left;
    public KeyCode right;
	public KeyCode up;
	public KeyCode down;

    void Update()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
            movement.x = -1;
        if (Input.GetKey(KeyCode.D))
            movement.x = 1;
        if (Input.GetKey(KeyCode.W))
            movement.y = 1;
        if (Input.GetKey(KeyCode.S))
            movement.y = -1;
    }

    void FixedUpdate()
    {
        // Apply movement to the physics body
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
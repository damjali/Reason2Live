using UnityEngine;

namespace Players
{
    public class Player  : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public Rigidbody2D rb;

        protected Vector2 movement;

        public virtual void Update()
        {
            movement = Vector2.zero;
        }
        void FixedUpdate()
        {
            // Apply movement to the physics body
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
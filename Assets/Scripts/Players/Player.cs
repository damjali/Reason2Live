using UnityEngine;

namespace Players
{
    public class Player  : MonoBehaviour
    {
        
        public bool haveUp {get; set;}
        public bool haveDown{get;set;}
        public bool haveLeft{get;set;}
        public bool haveRight{get;set;}
        
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
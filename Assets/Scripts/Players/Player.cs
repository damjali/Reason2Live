using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        
        [Header("Abilities")]
        public bool haveUp { get; set; }
        public bool haveDown { get; set; }
        public bool haveLeft { get; set; }
        public bool haveRight { get; set; }

        protected Rigidbody2D rb;
        protected Animator anim; // Reference to the Animator
        protected Vector2 movement;
        
        private float originX = 3;
        private float originY = 3;
        private bool originSaved = false;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        public virtual void Update()
        {
            // Capture starting position once
            if (!originSaved)
            {
                originX = transform.position.x;
                originY = transform.position.y;
                originSaved = true;
                Debug.Log($"Origin captured at: {originX}, {originY}");
            }

            // Reset movement each frame before Player1 adds input
            movement = Vector2.zero;
        }

        protected virtual void FixedUpdate()
        {
            // Apply movement physics
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Updates Animator parameters based on current movement vector.
        /// </summary>
        protected void UpdateAnimations()
        {
            if (anim != null)
            {
                // Check if the player is currently providing input
                bool isMoving = movement.sqrMagnitude > 0;
                
                // Set the Boolean to switch between Idle and Walk states
                anim.SetBool("IsMoving", isMoving);

                if (isMoving)
                {
                    // Update the Blend Tree coordinates
                    anim.SetFloat("MoveX", movement.x);
                    anim.SetFloat("MoveY", movement.y);
                }
            }
        }

        public void reset()
        {
            resetPosition();
        }

        private void resetPosition()
        {
            rb.position = new Vector2(originX, originY);
        }
    }
}
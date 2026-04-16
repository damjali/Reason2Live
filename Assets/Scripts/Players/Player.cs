using UnityEngine;

namespace Players
{
    public class Player  : MonoBehaviour
    {
        
        public bool haveUp {get; set;}
        public bool haveDown{get;set;}
        public bool haveLeft{get;set;}
        public bool haveRight{get;set;} 
        
        private float originX=3;
        private float originY=3;
        
        public float moveSpeed = 5f;
        private Rigidbody2D rb;

        protected Vector2 movement;
        private bool originSaved = false;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        public virtual void Update()
        {
            if (!originSaved)
            {
                originX = transform.position.x;
                originY = transform.position.y;
                originSaved = true;
                Debug.Log($"Origin captured at: {originX}, {originY}");
            }
            movement = Vector2.zero;
        }
        void FixedUpdate()  
        {
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
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
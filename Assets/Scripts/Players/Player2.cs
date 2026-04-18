using UnityEngine;
namespace Players
{
    public class Player2 : Player
    {
        public bool scared { get; set; } = false;

        public void Start()
        {
            haveDown = false;
            haveLeft = false;
            haveRight = false;
            haveUp = false;
        }
        
        public override void Update()
        {
            base.Update();
            if (scared)
            {
                return;
            }
            base.Update();
            if (Input.GetKey(KeyCode.LeftArrow) && haveLeft)
                movement.x = -1;
            if (Input.GetKey(KeyCode.RightArrow) && haveRight)
                movement.x = 1;
            if (Input.GetKey(KeyCode.UpArrow) && haveUp)
                movement.y = 1;
            if (Input.GetKey(KeyCode.DownArrow) && haveDown)
                movement.y = -1;

            UpdateAnimations();
        }

        public void scare()
        {
            scared = true;
            rb.linearVelocity = Vector2.zero; // Stop movement immediately
        }
    }
}
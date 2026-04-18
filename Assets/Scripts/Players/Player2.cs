using UnityEngine;

namespace Players
{
    public class Player2 : Player
    {
        // Start is used for initialization
        void Start()
        {
            // Ensure abilities are active
            haveDown = false;
            haveLeft = false;
            haveRight = false;
            haveUp = false;
        }

        public override void Update()
        {
            // 1. Reset movement vector in base class
            base.Update();

            // 2. Capture Keyboard Input (WASD)
            if (Input.GetKey(KeyCode.LeftArrow) && haveLeft)
                movement.x = -1;
            else if (Input.GetKey(KeyCode.RightArrow) && haveRight)
                movement.x = 1;

            if (Input.GetKey(KeyCode.UpArrow) && haveUp)
                movement.y = 1;
            else if (Input.GetKey(KeyCode.DownArrow) && haveDown)
                movement.y = -1;

            // 3. Update the animator parameters
            UpdateAnimations();
        }
    }
}
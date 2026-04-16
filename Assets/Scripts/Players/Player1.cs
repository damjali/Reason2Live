using UnityEngine;

namespace Players
{
    public class Player1 : Player
    {
        // Use Start to initialize abilities for this specific player
        public void Start()
        {
            haveDown = true;
            haveLeft = true;
            haveRight = true;
            haveUp = true;
        }

        public override void Update()
        {
            // 1. Run the base Update to reset movement and check origin
            base.Update();

            // 2. Capture Keyboard Input
            if (Input.GetKey(KeyCode.A) && haveLeft)
                movement.x = -1;
            else if (Input.GetKey(KeyCode.D) && haveRight)
                movement.x = 1;

            if (Input.GetKey(KeyCode.W) && haveUp)
                movement.y = 1;
            else if (Input.GetKey(KeyCode.S) && haveDown)
                movement.y = -1;

            // 3. Sync the visual animations with the movement
            UpdateAnimations();
        }
    }
}
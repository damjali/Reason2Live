using UnityEngine;

namespace Players
{
    public class Player1 : Player
    {
        public void Start()
        {
            haveDown = true;
            haveLeft = true;
            haveRight = true;
            haveUp = true;
        }
        public override void Update()
        {
            base.Update();
            if (Input.GetKey(KeyCode.A) && haveLeft)
                movement.x = -1;
            if (Input.GetKey(KeyCode.D) && haveRight)
                movement.x = 1;
            if (Input.GetKey(KeyCode.W) && haveUp)
                movement.y = 1;
            if (Input.GetKey(KeyCode.S) && haveDown)
                movement.y = -1;
        }
    }
}

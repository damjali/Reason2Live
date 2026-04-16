using UnityEngine;

namespace Players
{
    public class Player1 : Player
    {
        public override void Update()
        {
            base.Update();
            if (Input.GetKey(KeyCode.A))
                movement.x = -1;
            if (Input.GetKey(KeyCode.D))
                movement.x = 1;
            if (Input.GetKey(KeyCode.W))
                movement.y = 1;
            if (Input.GetKey(KeyCode.S))
                movement.y = -1;
        }
    }
}

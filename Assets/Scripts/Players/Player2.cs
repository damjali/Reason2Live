using UnityEngine;
namespace Players
{
    public class Player2 : Player
    {
        public override void Update()
        {
            base.Update();
            if (Input.GetKey(KeyCode.LeftArrow))
                movement.x = -1;
            if (Input.GetKey(KeyCode.RightArrow))
                movement.x = 1;
            if (Input.GetKey(KeyCode.UpArrow))
                movement.y = 1;
            if (Input.GetKey(KeyCode.DownArrow))
                movement.y = -1;
        }
    }
}
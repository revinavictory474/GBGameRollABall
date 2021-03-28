using UnityEngine;

namespace Geekbrains
{
    public sealed class PlayerBall : PlayerBase
    {
        private CharacterController _charController;


        private void Start()
        {
            _charController = GetComponent<CharacterController>();
        }
        public override void Move(float x, float y, float z)
        {
            Vector3 movement = new Vector3(x, y, z);
            movement = Vector3.ClampMagnitude(movement, Speed);
            movement.y = Gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }
    }
}

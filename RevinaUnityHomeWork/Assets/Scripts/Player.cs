using UnityEngine;

namespace Geekbrains
{
    public class Player : MonoBehaviour
    {
        public float Speed = 3.0f; 
        public float Gravity = -9.8f;
        private CharacterController _charController;

        private void Start()
        {
            _charController = GetComponent<CharacterController>();
        }

        protected void Move()
        {
            float deltaX = Input.GetAxis("Horizontal") * Speed;
            float deltaZ = Input.GetAxis("Vertical") * Speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed);
            movement.y = Gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }
    }
}

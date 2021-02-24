using UnityEngine;

namespace Geekbrains
{
    public class Player : MonoBehaviour
    {
        private float _speed = 3.0f;
        public float Speed { get => _speed; set => _speed = value; }
        public float Gravity = -9.8f;
        protected CharacterController _charController;


        protected void Start()
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

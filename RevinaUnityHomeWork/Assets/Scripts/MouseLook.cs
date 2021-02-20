using UnityEngine;

namespace Geekbrains
{
    public class MouseLook : MonoBehaviour
    {
        public enum RotationAxes
        {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }
        public RotationAxes axes = RotationAxes.MouseXAndY;
        private float sensitivityHor = 5.0f;
        private float sensitivityVert = 5.0f;
        private float minimumVert = -45.0f;
        private float maximumVert = 45.0f;
        private float _rotationX = 0;
        private void Start()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
                body.freezeRotation = true;
        }
        private void Update()
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}

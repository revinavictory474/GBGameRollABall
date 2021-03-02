using UnityEngine;

namespace Geekbrains
{
    public abstract class PlayerBase : MonoBehaviour
    {
        private float _speed = 3.0f;
        public float Speed { get => _speed; set => _speed = value; }
        public float Gravity = -9.8f;
        
        public abstract void Move(float x, float y, float z);
        
    }
}

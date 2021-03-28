using UnityEngine;
using static UnityEngine.Random;

namespace Geekbrains
{
    public abstract class InteractiveObjects : MonoBehaviour, IBoostable
    {
        protected Color _color;
        protected bool _isInteractable;

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        public void Action()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            { renderer.material.color = _color; }
        }

        public abstract void Boost();

        protected abstract void Interaction();

    }
}
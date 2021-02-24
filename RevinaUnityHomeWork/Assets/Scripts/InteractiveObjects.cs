using UnityEngine;

namespace Geekbrains
{
    public abstract class InteractiveObjects : MonoBehaviour, IInteractable, IBoostable
    {
        protected Color _color;
        protected Player player;
        public bool IsInteractable { get; } = true;

        private void Start()
        {
            Action();
        }
        public abstract void Boost();

        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Boost();
            Interaction();
            Destroy(gameObject);
        }

        public void Action()
        {
            _color = Random.ColorHSV();
            if(TryGetComponent(out Renderer renderer))
            { renderer.material.color = _color; }
        }
    }
}
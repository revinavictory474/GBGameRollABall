using UnityEngine;

namespace Geekbrains
{
    public abstract class InteractiveObjects : MonoBehaviour, IBoostable //, IExecute
    {
        protected Color _color;
        protected PlayerBase player;
        private bool _isInteractable;

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                 _isInteractable = value;
                 GetComponent<Renderer>().enabled = _isInteractable;
                 GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        protected virtual void Start()
        {
            player = FindObjectOfType<PlayerBase>();
            Action();
        }
        public abstract void Boost();

        protected abstract void Interaction();
        //public abstract void Execute();

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Boost();
            Interaction();
            Destroy(gameObject);
            IsInteractable = false;
        }

        public void Action()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if(TryGetComponent(out Renderer renderer))
            { renderer.material.color = _color; }
        }
    }
}
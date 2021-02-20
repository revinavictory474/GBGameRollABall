using UnityEngine;

namespace Geekbrains
{
    public abstract class InteractiveObjects : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;

        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }
    }
}
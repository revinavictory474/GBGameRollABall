using System.Collections;
using UnityEngine;

namespace Geekbrains
{
    public class Interactive : InteractiveObjects
    {

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
        public override void Boost()
        {
        }

        protected override void Interaction()
        {
        }
    }
}

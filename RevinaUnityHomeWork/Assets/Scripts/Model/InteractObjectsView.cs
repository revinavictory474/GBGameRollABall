using UnityEngine;

namespace Geekbrains
{
    public class InteractObjectsView : InteractiveObjects
    {
        
        protected PlayerBase player;

        public override void Boost()
        {
        }

        protected override void Interaction()
        {
        }

        protected virtual void Start()
        {
            player = FindObjectOfType<PlayerBase>();
            Action();
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObjects, IBoostable  
    {
        DisplayBonuses _displayBadBonuses;
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
        

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        private void Awake()
        {
            //_displayBadBonuses = new DisplayBonuses();
        }
        protected override void Start()
        {
            base.Start();
        }
        public override void Boost()
        {
            //Destroy(gameObject);
            //IsInteractable = false;
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            
            _displayBadBonuses.Display(-5);
            Destroy(gameObject);
        }

        //public override void Execute()
        //{
        //    if (!IsInteractable) { return; }
        //    Boost();
        //}
    }
}
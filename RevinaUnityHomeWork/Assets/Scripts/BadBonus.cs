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
        public override void Boost()
        {
            Destroy(player.gameObject);
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            
            _displayBadBonuses.Display(-5);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Boost();
        }
    }
}
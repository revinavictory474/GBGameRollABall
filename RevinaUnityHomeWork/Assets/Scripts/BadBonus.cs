using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObjects, IBoostable  
    {
        DisplayBonuses _displayBadBonuses;

        public int Score = 5;

        private event EventHandler<Color> _caughtPlayer;
        public event EventHandler<Color> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        private void Awake()
        {
            _displayBadBonuses = new DisplayBonuses();
        }
        public override void Boost()
        {
            Destroy(player.gameObject);
        }

        protected override void Interaction()
        {
            _caughtPlayer?.Invoke(this, _color);
            _displayBadBonuses._score -= Score;
            _displayBadBonuses.Display();
        }
    }
}
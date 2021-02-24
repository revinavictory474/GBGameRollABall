using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class GoodBonus : InteractiveObjects, IBoostable, IEquatable<GoodBonus>
    {
        private DisplayBonuses _displayBonuses;
        public int Point;
        private float _speedPlus;
        private float _speedBoost = 2;
        public int Score = 5;

        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
        }
        public override void Boost()
        {
            _speedPlus = player.Speed * _speedBoost;
            player.Speed += _speedPlus;
            Destroy(this, 4);
        }

        protected override void Interaction()
        {
            _displayBonuses._score += Score;
            _displayBonuses.Display();
        }

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }
    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class GoodBonus : InteractiveObjects, IBoostable, IEquatable<GoodBonus>
    {
        private DisplayBonuses _displayBonuses;
        public int Point;

        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
        }
        public void Boost()
        {

        }

        protected override void Interaction()
        {
            _displayBonuses.Display(5);
        }

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }
    }
}
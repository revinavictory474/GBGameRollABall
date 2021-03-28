using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class GoodBonus : InteractiveObjects, IBoostable, IEquatable<GoodBonus>
    {
        protected DisplayBonuses _displayBonuses;
        public event Action<int> OnPointChange = delegate (int i) { };
        public int Point;
        protected int score = 5;
        protected float _speedPlus;
        protected float _speedBoost = 2;
        PlayerBall player;

        public override void Boost()
        {
            _speedPlus = player.Speed * _speedBoost;
            player.Speed += _speedPlus;
            Destroy(this, 4);
        }

        protected override void Interaction()
        {
            _displayBonuses.Display(score);
            OnPointChange.Invoke(Point);
        }

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }

    }
}
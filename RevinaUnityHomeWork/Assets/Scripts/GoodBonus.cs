using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class GoodBonus : InteractiveObjects, IBoostable, IEquatable<GoodBonus>
    {
        private DisplayBonuses _displayBonuses;
        public event Action<int> OnPointChange = delegate (int i) { };
        public int Point;
        private float _speedPlus;
        private float _speedBoost = 2;
        private Material _material;


        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            //_displayBonuses = new DisplayBonuses();
        }
        public override void Boost()
        {
            _speedPlus = player.Speed * _speedBoost;
            player.Speed += _speedPlus;
            Destroy(this, 4);
        }

        protected override void Interaction()
        {
            _displayBonuses.Display(5);
            OnPointChange.Invoke(Point);
        }

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Boost();
        }
    }
}
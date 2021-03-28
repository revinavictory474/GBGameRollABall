using System;
using UnityEngine;

namespace Geekbrains
{
    public class BadBonus : InteractiveObjects, IBoostable  
    {
        DisplayBonuses _displayBadBonuses;
        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
       
        
        public override void Boost()
        {
            Destroy(gameObject);
            //IsInteractable = false;
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            
            _displayBadBonuses.Display(-5);
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace Geekbrains    
{
    public class GoodBonusView : GoodBonus
    {
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }
    }
}
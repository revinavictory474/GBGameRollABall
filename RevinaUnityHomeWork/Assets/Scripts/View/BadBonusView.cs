using UnityEngine;

namespace Geekbrains
{
    public class BadBonusView : BadBonus
    {
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }
    }
}
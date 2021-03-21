using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public class RadarModel : MonoBehaviour
    {
        protected Transform _playerPos; 
        protected readonly float _mapScale = 2;
        protected static List<RadarObject> RadObjects = new List<RadarObject>();

        private void Start()
        {
            _playerPos = Camera.main.transform;
        }

        public sealed class RadarObject
        {
            public Image Icon;
            public GameObject Owner;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
	public sealed class RadarObj : MonoBehaviour
	{
		[SerializeField] private Image _ico;

        private void OnValidate()
        {
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
        }

        private void OnDisable()
		{
			RadarController.RemoveRadarObject(gameObject);
		}

		private void OnEnable()
		{
			RadarController.RegisterRadarObject(gameObject, _ico);
		}
	}
}
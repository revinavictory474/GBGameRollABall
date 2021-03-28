using UnityEngine;

namespace Geekbrains
{
    public class RadarView : RadarModel
    {
		private void Update()
		{
			if (Time.frameCount % 2 == 0)
			{
				DrawRadarDots();
			}
		}

		private void DrawRadarDots() 
		{
			foreach (RadarObject radObject in RadObjects)
			{
				Vector3 radarPos = (radObject.Owner.transform.position - _playerPos.position);
				float distToObject = Vector3.Distance(_playerPos.position, radObject.Owner.transform.position) * _mapScale;
				float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _playerPos.eulerAngles.y;
				radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
				radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
				radObject.Icon.transform.SetParent(transform);
				radObject.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + transform.position;
			}
		}
	}
}
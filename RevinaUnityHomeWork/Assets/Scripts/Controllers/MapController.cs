using UnityEngine;

namespace Geekbrains
{
	public class MapController : MapModel
	{
		private void LateUpdate()
		{
			var newPosition = _player.position;
			newPosition.y = transform.position.y;
			transform.position = newPosition;
			transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
		}
	}
}
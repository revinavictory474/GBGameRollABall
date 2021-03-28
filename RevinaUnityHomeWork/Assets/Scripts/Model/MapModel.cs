using UnityEngine;

namespace Geekbrains
{
	public class MapModel : MonoBehaviour
	{
		protected Transform _player;
		private void Start()
		{
			_player = Camera.main.transform;
			transform.parent = null;
			transform.rotation = Quaternion.Euler(90.0f, 0, 0);
			transform.position = _player.position + new Vector3(0, 5.0f, 0);
		}
	}
}
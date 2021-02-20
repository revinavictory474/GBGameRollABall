using UnityEngine;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour
    {
        private InteractiveObjects[] _interactiveObjects;
        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObjects>();
        }

        private void Start()
        {
            Player player = new PlayerBall();
        }
        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IBoostable boost)
                {
                    boost.Boost();
                }
            }
        }

    }
}
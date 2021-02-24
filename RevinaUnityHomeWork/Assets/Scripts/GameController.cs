using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour
    {
        public Text _finishGameLabel;
        private ListInteractableObject _interactiveObjects;
        private DisplayEndGame _displayEndGame;

        private void Awake()
        {
            _interactiveObjects = new ListInteractableObject();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            foreach (var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }
            }

        }

        private void CaughtPlayer(object value, Color color)
        {
            Time.timeScale = 0.0f;
        }
        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
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
        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObjects interactiveObject)
                {
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                    Destroy(interactiveObject.gameObject);
                }
            }
        }


    }
}
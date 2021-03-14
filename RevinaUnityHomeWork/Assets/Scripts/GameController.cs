using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private CameraController _cameraController;
        private ListExecuteObject _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private InputController _inputController;
        private int _countBonuses;
        private Reference _reference;

        private void Awake()
        {
            _interactiveObjects = new ListExecuteObject();

            var _reference = new Reference();
            PlayerBase player = _reference.PlayerBall;

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            _inputController = new InputController(player);
            _interactiveObjects.AddExecuteObject(_inputController);

            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            foreach (var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            new GameObject().AddComponent<PlayerBall>();
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }


        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 1.0f;
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
                interactiveObject.Execute();
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
                        badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                        badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                    }
                    if (o is GoodBonus goodBonus)
                    {
                        goodBonus.OnPointChange -= AddBonuse;
                    }
                }
            }
        }
    }
}
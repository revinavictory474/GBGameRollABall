using System;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class DisplayEndGame 
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLabel)
        {
            try
            {
                _finishGameLabel = finishGameLabel;
                _finishGameLabel.text = String.Empty;
            }
            catch
            {
                Debug.Log("finishGameLabel is missing");
            }
            finally
            {
                Debug.Log("Block finally");
            }
        }

        public void GameOver(object o, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {((GameObject)o).name} {color} цвета";
        }

    }
}
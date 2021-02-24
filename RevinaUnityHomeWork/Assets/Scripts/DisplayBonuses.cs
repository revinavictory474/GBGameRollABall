using UnityEngine.UI;
using UnityEngine;

namespace Geekbrains
{
    public sealed class DisplayBonuses 
    {
        private Text _text;
        public int _score;

        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
        }

        public void Display()
        {
            _text.text = $"Вы набрали {_score} очков!";
        }
    }
}
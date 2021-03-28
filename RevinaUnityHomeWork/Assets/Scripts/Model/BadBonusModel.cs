using System;

namespace Geekbrains
{
    public class BadBonusModel : BadBonus
    {
        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;

        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }
    }
}
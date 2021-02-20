namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObjects, IBoostable  
    {
        DisplayBonuses _displayBadBonuses;
        Player player;

        private void Awake()
        {
            _displayBadBonuses = new DisplayBonuses();
        }
        public void Boost()
        {
            Destroy(player.gameObject);
        }

        protected override void Interaction()
        {
            _displayBadBonuses.Display(-5);
        }
    }
}
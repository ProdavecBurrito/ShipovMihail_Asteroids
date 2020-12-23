namespace Shipov_Asteroids
{
    internal sealed class Health
    {
        public float GetMaxHP { get; }
        public float GetCurrentHP { get; private set; }

        public Health(float maxHP, float currentHP)
        {
            GetMaxHP = maxHP;
            GetCurrentHP = currentHP;
        }

        public void ChangeCurrentHealth(float hp)
        {
            GetCurrentHP = hp;
        }
    }
}


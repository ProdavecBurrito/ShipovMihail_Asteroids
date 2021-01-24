namespace Shipov_Asteroids
{
    internal sealed class Health
    {
        public float MaxHP { get; }
        public float CurrentHP { get; private set; }

        public Health(float maxHP, float currentHP)
        {
            MaxHP = maxHP;
            CurrentHP = currentHP;
        }

        public void ChangeCurrentHealth(float hp)
        {
            CurrentHP = hp;
        }

        public void GetDamage(float damage)
        {
            CurrentHP -= damage;
        }
    }
}


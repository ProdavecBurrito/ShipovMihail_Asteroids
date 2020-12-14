using UnityEngine;

namespace Shipov_Asteroids
{
    internal abstract class BaseEnemy : MonoBehaviour
    {
        public Health Health { get; private set; }
        public static Asteroid CreateAsteroid(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }

        public void InjectHealth(Health health)
        {
            Health = health;
        }
    }
}

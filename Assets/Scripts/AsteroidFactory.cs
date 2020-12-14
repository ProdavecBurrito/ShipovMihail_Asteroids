using UnityEngine;

namespace Shipov_Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public BaseEnemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));

            enemy.InjectHealth(hp);

            return enemy;
        }
    }
}

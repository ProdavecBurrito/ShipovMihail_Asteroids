using UnityEngine;

namespace Shipov_Asteroids
{
    public class BaseBullet : MonoBehaviour
    {
        private const float DAMAGE = 10.0f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<BaseEnemy>(out var enemy))
            {
                enemy.Health.GetDamage(DAMAGE);
                Destroy(gameObject);
            }
        }
    }
}

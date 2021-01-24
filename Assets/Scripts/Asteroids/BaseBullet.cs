using UnityEngine;

namespace Shipov_Asteroids
{
    public class BaseBullet : MonoBehaviour
    {
        private const float DAMAGE = 10.0f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Bre");
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Lol");
                other.GetComponent<BaseEnemy>().Health.GetDamage(DAMAGE);
                Destroy(gameObject);
            }
        }
    }
}

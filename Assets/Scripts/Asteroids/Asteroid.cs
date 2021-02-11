using UnityEngine;

namespace Shipov_Asteroids
{
    internal sealed class Asteroid : BaseEnemy, IAsteroidMove, IUpdate
    {
        private const int HIT_DAMAGE = 5;
        private const float MIN_SPEED = 2.0f;
        private const float MAX_SPEED = 5.0f;
        private const float MIN_DIRECTIOON = -1.0f;
        private const float MAX_DIRECTIOON = 1.0f;

        private float _health = 50.0f;
        private Vector3 _direction;
        private Transform _transform;

        public float Speed { get; private set; }

        public void InitAsteroid(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;
            Health = new Health(_health ,_health);
            Speed = Random.Range(MIN_SPEED, MAX_SPEED);
            _transform = gameObject.transform;
            _direction.x = Random.Range(MIN_DIRECTIOON, MAX_DIRECTIOON);
            _direction.y = Random.Range(MIN_DIRECTIOON, MAX_DIRECTIOON);
        }

        public void UpdateTick()
        {
            Move();
        }

        public void Move()
        {
            _direction.Set(_direction.x, _direction.y, 0.0f);
            _transform.localPosition += _direction * Speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Ship>().GetDamage(HIT_DAMAGE);
                Health.ChangeCurrentHealth(0);
                _health = Health.CurrentHP;
            }
        }

    }
}

using UnityEngine;

namespace Shipov_Asteroids
{
    internal sealed class Asteroid : BaseEnemy, IAsteroidMove, IUpdate
    {
        public float Speed { get; private set; }
        private Vector3 _direction;
        private Transform _transform;
        
        public void InitAsteroid()
        {
            Speed = Random.Range(2f, 5f);
            _transform = gameObject.transform;
            _direction.x = Random.Range(-1.0f, 1.0f);
            _direction.y = Random.Range(-1.0f, 1.0f);
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
    }
}

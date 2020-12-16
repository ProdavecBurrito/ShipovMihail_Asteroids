using UnityEngine;

namespace Shipov_Asteroids
{
    internal sealed class Asteroid : BaseEnemy, IAsteroidMove, IUpdate
    {
        public float Speed { get; protected set; }
        private Vector3 _direction;
        private Transform _transform;
        
        public void InitAsteroid()
        {
            _transform = gameObject.transform;
            _direction.x = Random.Range(0.01f, 0.05f);
            _direction.y = Random.Range(0.01f, 0.05f);
            //Speed = speed;
        }

        public void UpdateTick()
        {
            Move();
        }

        public void Move()
        {
            _direction.Set(_direction.x, _direction.y, Time.deltaTime);
            _transform.localPosition += _direction;
        }
    }
}

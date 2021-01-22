using UnityEngine;

namespace Shipov_Asteroids
{
    internal class Movement : IMove
    {
        private readonly Transform _transform;
        private Vector3 _movementVector;

        public float Speed { get; protected set; }

        public Movement(Transform transform, float speed)
        {
            Speed = speed;
            _transform = transform;
        }

        public void Move(float vertical, float horizontal, float deltaTime)
        {
            _movementVector.Set(horizontal, vertical, 0.0f);
            _transform.Translate(_movementVector * Speed * deltaTime, Space.Self);
        }
    }
}

using UnityEngine;

namespace Shipov_Asteroids
{
    internal class AccelerationMovement : Movement
    {
        private readonly float _acceleration;
        public AccelerationMovement(Transform transform, float speed, float acceleration) : base(transform, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}

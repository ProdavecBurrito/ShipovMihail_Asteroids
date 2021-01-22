using UnityEngine;

namespace Shipov_Asteroids
{
    internal class Ship : IMove, IRotation, IShoot
    {
        private readonly IMove _movementRealization;
        private readonly IRotation _rotationRealization;
        private readonly IShoot _shootRealization;
        private PlayerSO _playerSO;

        public float Speed => _movementRealization.Speed;

        public Ship(IMove move, IRotation rotation, IShoot shoot, PlayerSO playerSO)
        {
            _playerSO = playerSO;
            _shootRealization = shoot;
            _movementRealization = move;
            _rotationRealization = rotation;
        }

        public void Move(float vertical, float horizontal, float deltaTime)
        {
            _movementRealization.Move(vertical, horizontal, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationRealization.Rotation(direction);
        }

        public void Shoot()
        {
            _shootRealization.Shoot();
        }

        public void AddAcceleration()
        {
            if (_movementRealization is AccelerationMovement accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_movementRealization is AccelerationMovement accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void GetDamage(int damage)
        {
            if (_playerSO.hp <= 0)
            {
                // Destroy
            }
            else
            {
                _playerSO.hp -= damage;
            }
        }
    }
}

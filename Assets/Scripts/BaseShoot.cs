using UnityEngine;

namespace Shipov_Asteroids
{
    internal class BaseShoot : IShoot
    {
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        private readonly float _force;

        public BaseShoot(Rigidbody2D bullet, Transform barrel, float force)
        {
            _force = force;
            _bullet = bullet;
            _barrel = barrel;
        }

        public void Shoot()
        {
            var temAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
        }
    }
}

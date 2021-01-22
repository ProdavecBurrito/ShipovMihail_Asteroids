using UnityEngine;


namespace Shipov_NotAsteroidHW
{
    public class Weapon : IAttack
    {
        private Transform _barrelPosition;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;
        private float _force;

        private IAmmoType _bullet;

        public Weapon(IAmmoType bullet, Transform barrelPosition, float force, AudioSource audioSource, AudioClip audioClip)
        {
            _bullet = bullet;
            _barrelPosition = barrelPosition;
            _force = force;
            _audioSource = audioSource;
            _audioClip = audioClip;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPosition = barrelPosition;
        }

        public void SetBullet(IAmmoType bullet)
        {
            _bullet = bullet;
        }

        public void SetForce(float force)
        {
            _force = force;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public void Attack()
        {
            var bullet = Object.Instantiate(_bullet.GetAmmoInstance, _barrelPosition.position, Quaternion.identity);
            bullet.AddForce(_barrelPosition.forward * _force);
            Object.Destroy(bullet.gameObject, _bullet.GetLifeTime);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}

using UnityEngine;

namespace Shipov_NotAsteroidHW
{
    internal class SilencerModification : WeaponModification
    {
        private AudioSource _audioSource;
        private IBarrel _muffler;
        private Vector3 _mufflerPosition;

        public SilencerModification(AudioSource audioSource, IBarrel muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            var muffler = Object.Instantiate(_muffler.BarrelInstance, _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeOfBarrelFire;
            weapon.SetAudioClip(_muffler.AudioClipBarrel);
            weapon.SetBarrelPosition(_muffler.BarrelPosition);
            return weapon;
        }
    }
}

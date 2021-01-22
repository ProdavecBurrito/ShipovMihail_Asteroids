using UnityEngine;

namespace Shipov_NotAsteroidHW
{
    public class WeaponBuilder : MonoBehaviour
    {
        private IAttack _fire;

        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _baseAudioClip;

        [Header("Silenced Gun")]
        [SerializeField] private AudioClip _silencedAudioClip;
        [SerializeField] private float _volumeOfSilencedGun;
        [SerializeField] private Transform _barrelPositionSilencer;
        [SerializeField] private GameObject _Silencer;


        private void Start()
        {
            IAmmoType ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _baseAudioClip);

            var silencer = new Silencer(_silencedAudioClip, _volumeOfSilencedGun, _barrelPosition, _Silencer);
            WeaponModification modificationWeapon = new SilencerModification(_audioSource, silencer, _barrelPositionSilencer.position);
            modificationWeapon.ApplyModification(weapon);
            _fire = modificationWeapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Attack();
            }
        }
    }
}

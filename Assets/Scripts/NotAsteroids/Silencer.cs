using UnityEngine;


namespace Shipov_NotAsteroidHW 
{
    public class Silencer : IBarrel
    {
        public AudioClip AudioClipBarrel { get; }
        public float VolumeOfBarrelFire { get; }
        public Transform BarrelPosition { get; }
        public GameObject BarrelInstance { get; }

        public Silencer(AudioClip audioClip, float volumeOfFire, Transform barrelPosition, GameObject barrelInstance)
        {
            AudioClipBarrel = audioClip;
            VolumeOfBarrelFire = volumeOfFire;
            BarrelPosition = barrelPosition;
            BarrelInstance = barrelInstance;
        }

    }
}

using UnityEngine;

namespace Shipov_NotAsteroidHW
{
    internal interface IBarrel
    {
        AudioClip AudioClipBarrel { get; }
        float VolumeOfBarrelFire { get; }
        Transform BarrelPosition { get; }
        GameObject BarrelInstance { get; }
    }
}
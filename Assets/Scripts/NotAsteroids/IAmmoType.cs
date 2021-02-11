using UnityEngine;

namespace Shipov_NotAsteroidHW
{
    public interface IAmmoType
    {
        Rigidbody GetAmmoInstance { get; }
        float GetLifeTime { get; }
    }
}

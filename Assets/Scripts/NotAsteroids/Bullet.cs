using UnityEngine;

namespace Shipov_NotAsteroidHW
{
    public class Bullet : IAmmoType
    {
        public Rigidbody GetAmmoInstance { get; }
        public float GetLifeTime { get; }

        public Bullet(Rigidbody ammoInstance, float lifeTime)
        {
            GetAmmoInstance = ammoInstance;
            GetLifeTime = lifeTime;
        }

    }
}

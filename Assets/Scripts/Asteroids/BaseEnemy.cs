using System;
using UnityEngine;

namespace Shipov_Asteroids
{
    internal abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        public event Action<string, string> OnDestroy = delegate (string name, string hp) {};

        public static IEnemyFactory Factory;
        private Transform _rotPool;
        private Health _health;
        protected EnemyPool _enemyPool;

        public Health Health
        {
            get
            {
                if (_health.CurrentHP <= 0.0f)
                {
                    OnDestroy?.Invoke(gameObject.name, _health.CurrentHP.ToString());
                    _enemyPool.ReturnToPool(transform);
                }
                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.ASTEROID_POOL);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }
    }
}

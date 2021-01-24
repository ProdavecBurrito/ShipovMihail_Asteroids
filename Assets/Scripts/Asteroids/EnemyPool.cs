using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Shipov_Asteroids
{
    internal sealed class EnemyPool
    {
        private readonly Dictionary<string, HashSet<BaseEnemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public int CapacityPool => _capacityPool;

        public EnemyPool(int capacityPool)
        {
            _enemyPool = new Dictionary<string, HashSet<BaseEnemy>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.ASTEROID_POOL).transform;
            }
        }

        public BaseEnemy GetEnemy(string enemyType)
        {
            BaseEnemy result;
            switch (enemyType)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(enemyType));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, "Такого типа противника не существует");
            }
            return result;
        }

        private HashSet<BaseEnemy> GetListEnemies(string type)
        {
            if (_enemyPool.ContainsKey(type))
            {
                return _enemyPool[type];
            }

            else
            {
                return _enemyPool[type] = new HashSet<BaseEnemy>();
            }
        }

        private BaseEnemy GetAsteroid(HashSet<BaseEnemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);

            if (enemy == null)
            {
                var asteroid = Resources.Load<Asteroid>("Enemy/Asteroid");
                for (var i = 0; i < CapacityPool; i++)
                {
                    var instantiate = Object.Instantiate(asteroid);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
                GetAsteroid(enemies);
            }

            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        public void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}

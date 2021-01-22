using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Shipov_Asteroids
{
    public class BulletPool : MonoBehaviour
    {
        internal sealed class EnemyPool
        {
            private readonly Dictionary<string, HashSet<BaseShoot>> _bulletPool;
            private readonly int _capacityPool;
            private Transform _rootPool;

            public int CapacityPool => _capacityPool;

            public EnemyPool(int capacityPool)
            {
                _bulletPool = new Dictionary<string, HashSet<BaseShoot>>();
                _capacityPool = capacityPool;
                if (!_rootPool)
                {
                    _rootPool = new GameObject(NameManager.ASTEROID_POOL).transform;
                }
            }

            public BaseShoot GetBulleType(string bulletType)
            {
                BaseShoot result;
                switch (bulletType)
                {
                    case "Bullet":
                        result = GetBullets(GetListBullets(bulletType));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(bulletType), bulletType, "Такого типа снарядов не существует");
                }
                return result;
            }

            private HashSet<BaseShoot> GetListBullets(string type)
            {
                if (_bulletPool.ContainsKey(type))
                {
                    return _bulletPool[type];
                }

                else
                {
                    return _bulletPool[type] = new HashSet<BaseShoot>();
                }
            }

            private BaseShoot GetBullets(HashSet<BaseShoot> bullets)
            {
                var currentBullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);

                if (currentBullet == null)
                {
                    var bullet = Resources.Load<BaseShoot>("Bullet");
                    for (var i = 0; i < CapacityPool; i++)
                    {
                        var instantiate = Object.Instantiate(bullet);
                        ReturnToPool(instantiate.transform);
                        bullets.Add(instantiate);
                    }
                    GetBullets(bullets);
                }

                currentBullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
                return currentBullet;
            }

            private void ReturnToPool(Transform transform)
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
}

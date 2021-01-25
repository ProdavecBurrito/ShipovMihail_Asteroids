using UnityEngine;

namespace Shipov_Asteroids
{
    internal class DamageListener : MonoBehaviour
    {
        public void Add(BaseEnemy enemy)
        {
            enemy.OnDestroy += ValueOnHitChange;
        }
        public void Remove(BaseEnemy enemy)
        {
            enemy.OnDestroy -= ValueOnHitChange;
        }
        private void ValueOnHitChange(string name, string hp)
        {
            Debug.Log($"{ name} + {hp}");
        }

    }
}

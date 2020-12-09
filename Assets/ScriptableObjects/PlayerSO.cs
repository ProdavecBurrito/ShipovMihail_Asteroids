using UnityEngine;

namespace Shipov_Asteroids
{
    [CreateAssetMenu(fileName = "Player")]
    internal class PlayerSO : ScriptableObject
    {
        [SerializeField] public float speed;
        [SerializeField] public float acceleration;
        [SerializeField] public float hp;
        [SerializeField] public float force;
    }
}

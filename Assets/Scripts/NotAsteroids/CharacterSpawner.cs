using UnityEngine;
using System.Collections.Generic;

namespace Shipov_NotAsteroidHW
{
    public class CharacterSpawner : MonoBehaviour
    {
        private List<Character> _characters;

        private void Start()
        {
            _characters = new List<Character>();

            var mage = new Character(new JumpingMovement(), new MagicAttack());
            _characters.Add(mage);

            var warrior = new Character(new GroundMovement(), new PhysicalAttack());
            _characters.Add(warrior);

            var eagleRogue = new Character(new FlyingMovement(), new RangePhysicalAttack());
            _characters.Add(eagleRogue);

            foreach (Character item in _characters)
            {
                item.Attack();
                item.Move();
            }
        }
    }
}

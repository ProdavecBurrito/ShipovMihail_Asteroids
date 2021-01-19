using UnityEngine;

namespace Shipov_Asteroids
{
    internal class ReduceSpeedChain : ChainMember
    {
        private Ship _ship;

        public ReduceSpeedChain(Ship ship)
        {
            _ship = ship;
        }

        public override IChainMember Act()
        {
            _ship.RemoveAcceleration();
            return base.Act();
        }
    }
}

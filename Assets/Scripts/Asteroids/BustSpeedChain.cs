
namespace Shipov_Asteroids
{
    internal class BustSpeedChain : ChainMember, IUpdate
    {
        private const float BUST_TIME = 3.0f;

        private Ship _ship;
        private Timer _timer = new Timer();

        public void UpdateTick()
        {
            if (_timer.IsOn)
            {
                _timer.CountTime();
            }
        }

        public BustSpeedChain(Ship ship)
        {
            _ship = ship;
        }

        public override IChainMember Act()
        {
            _timer.Init(BUST_TIME);
            if (_timer.IsOn)
            {
                _ship.AddAcceleration();
                return this;
            }
            else
            {
                return base.Act();
            }
        }
    }
}

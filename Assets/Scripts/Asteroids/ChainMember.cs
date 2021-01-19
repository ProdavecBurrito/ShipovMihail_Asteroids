namespace Shipov_Asteroids
{
    internal class ChainMember : IChainMember
    {
        private IChainMember _nextHandler;

        public IChainMember TransferToNext(IChainMember handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual IChainMember Act()
        {
            if (_nextHandler != null)
            {
                _nextHandler.Act();
            }

            return _nextHandler;
        }

    }
}

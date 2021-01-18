namespace Shipov_Asteroids
{
    internal interface IChainMember
    {
        IChainMember Act();
        IChainMember TransferToNext(IChainMember nextMember);
    }
}

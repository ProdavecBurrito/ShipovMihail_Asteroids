namespace Shipov_Asteroids
{
    internal interface IEnemyFactory
    {
        BaseEnemy Create(Health health);
    }
}

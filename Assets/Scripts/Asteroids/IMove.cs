namespace Shipov_Asteroids
{
    internal interface IMove
    {
        float Speed { get; }
        void Move(float vertical,float horizontal, float deltaTime);
    }
}
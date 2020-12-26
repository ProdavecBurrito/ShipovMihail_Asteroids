namespace Shipov_NotAsteroidHW
{
    public class Character
    {
        private IMovement _movement;
        private IAttack _attack;

        public Character(IMovement movement, IAttack attack)
        {
            _movement = movement;
            _attack = attack;
        }

        public void Attack()
        {
            _attack.Attack();
        }

        public void Move()
        {
            _movement.Move();
        }
    }
}

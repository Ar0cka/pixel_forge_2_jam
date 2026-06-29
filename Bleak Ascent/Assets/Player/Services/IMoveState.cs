namespace Player.Services
{
    public interface IMoveState
    {
        public bool IsAttacking { get; }
        bool CanMove();
    }
}
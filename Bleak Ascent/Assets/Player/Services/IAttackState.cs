namespace Player.Services
{
    public interface IAttackState
    {
        void SetAttack(bool isAttack);
        bool CanAttack();
    }
}
namespace Player.Services
{
    public class StateController 
    {
        public bool IsUIVisible { get; private set; }
        public bool IsAttacking { get; private set; }
        
        public void SetUIVisibility(bool isVisible) => IsUIVisible = isVisible;
        public void SetAttack(bool isAttack) => IsAttacking = isAttack;
    }
}
namespace Player.Services
{
    public class StateController : IMoveState, IAttackState
    {
        private bool _isUIVisible;
        private bool _isAttacking;
        private bool _isRolling;
        
        public bool IsAttacking => _isAttacking;
        
        public void SetUIVisibility(bool isVisible) => _isUIVisible = isVisible;
        public void SetAttack(bool isAttack) => _isAttacking = isAttack;
        
        public bool CanAttack() => !_isUIVisible && !_isAttacking;
  
        public bool CanMove() => !_isUIVisible;
    }
}
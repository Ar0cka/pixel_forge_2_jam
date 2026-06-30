using UnityEngine;

namespace Units.CoreUnits
{
    public abstract class UnitsMove<TConfig> : MonoBehaviour where TConfig : ScriptableObject
    {
        [SerializeField] protected SpriteRenderer spriteRenderer;
        [SerializeField] protected Animator animator;
        [SerializeField] protected TConfig config;

        protected UnitMoveStates CurrentState = UnitMoveStates.Idle;
        
        protected abstract void Patrol();
        protected abstract void Move(Transform target);
    }
}
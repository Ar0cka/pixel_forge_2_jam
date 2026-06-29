using Player.Services;
using UnityEngine;

namespace Player.AttackSystem
{
    public class MileAttackInfo : AttackInfo
    {
        public Transform AttackPoint;
        
        public MileAttackInfo(Animator animator, IAttackState stateController,
            Rigidbody2D rb, Transform attackPoint, LayerMask layerToAttack) : base(animator, stateController, rb, layerToAttack)
        {
            AttackPoint = attackPoint;
        }
    }
}
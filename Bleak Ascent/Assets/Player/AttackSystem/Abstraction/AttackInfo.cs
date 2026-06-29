using System.Collections.Generic;
using Player.Services;
using UnityEngine;

namespace Player.AttackSystem
{
    public class AttackInfo
    {
        public AttackInfo(Animator animator, IAttackState stateController, Rigidbody2D rb, LayerMask layersToAttack)
        {
            Animator = animator;
            StateController = stateController;
            Rb = rb;
            LayersToAttack = layersToAttack;
        }
        
        public Animator Animator;
        public IAttackState StateController;
        public Rigidbody2D Rb;
        public LayerMask LayersToAttack;
    }
}
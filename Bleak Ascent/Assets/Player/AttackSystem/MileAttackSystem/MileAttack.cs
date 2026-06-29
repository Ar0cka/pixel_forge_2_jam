using Player.AttackSystem.Abstraction;
using Player.HealthSystem;
using SoConfigs;
using UnityEngine;

namespace Player.AttackSystem
{
    public class MileAttack : AttackAbstract<AttackConfig, MileAttackInfo>
    {
        
        public override void Execute()
        {
            if (!Info.StateController.CanAttack() || !CanExecute())
                return;

            var attackDelay = Config.castTime;

            while (attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
            }

            var results = new Collider2D[32];
            
            var size = Physics2D.OverlapCircleNonAlloc(Info.AttackPoint.position, Config.attackDamage, results, Info.LayersToAttack);

            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    var target = results[i];

                    if (target.CompareTag("Unit"))
                    {
                        target.GetComponent<Health>().TakeDamage(Config.attackDamage);
                    }
                }
            }
            
            Info.StateController.SetAttack(false);
            Info.Animator.ResetTrigger(Config.attackAnimationName);
            CooldownTime = Config.cooldown;
        }
        
    }
}
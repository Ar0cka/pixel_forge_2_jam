using Player.AttackSystem.Abstraction;
using SoConfigs;
using UnityEngine;

namespace Player.AttackSystem.CastSpellSystem
{
    public class CastSpell : AttackAbstract<SpellConfig, SpellInfo>
    {
        public override void Execute()
        {
            if (!Info.StateController.CanAttack() || !CanExecute())
                return;

            Info.StateController.SetAttack(true);
            
            Info.Animator.SetTrigger(Config.spellAnimationName);
            var animationDelay = Config.castDelay;

            while (animationDelay > 0)
            {
                animationDelay -= Time.deltaTime;
            }

            var spellPrefab = Info.PrefabFactory.CreateSpell(Config.spellPrefab, Info.StartSpellPoint.position);
            //TODO set spell color to spell prefab
            
            Info.StateController.SetAttack(false);
            
        }
    }
}
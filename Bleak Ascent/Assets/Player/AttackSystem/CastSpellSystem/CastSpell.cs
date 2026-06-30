using System.Collections;
using Player.AttackSystem.Abstraction;
using SoConfigs;
using Spell;
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

            StartCoroutine(Spawn(Config.castDelay));
        }

        private IEnumerator Spawn(float animationDelay)
        {
            yield return new WaitForSeconds(animationDelay);
            
            var spellPrefab = Info.PrefabFactory.CreateSpell(Config.spellPrefab, Info.StartSpellPoint.position);
            var spellLogic = spellPrefab.GetComponent<SpellLogic>();
            spellLogic.Initialize(Config, Info.LayersToAttack);
            
            Info.StateController.SetAttack(false);
            CooldownTime = Config.cooldown;
        }
    }
}
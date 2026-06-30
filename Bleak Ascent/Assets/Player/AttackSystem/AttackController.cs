using System;
using Player.AttackSystem.CastSpellSystem;
using Player.AttackSystem.MileAttackSystem;
using Player.CorruptedSystem;
using Player.Services;
using SoConfigs;
using UnityEngine;

namespace Player.AttackSystem
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private LayerMask targetMask;
        [SerializeField] private CorruptSystem corruptSystem;

        [SerializeField] private PrefabFactory prefabFactory;

        [SerializeField] private Transform attackPoint;
        
        [SerializeField] private CastSpell castSpell;
        [SerializeField] private MileAttack mileAttack;

        private StateController _stateController;

        private bool _isInitialize;

        public void Initialize(StateController stateController, PlayerConfig config)
        {
            _stateController = stateController;

            SpellInfo spellInfo = new SpellInfo(animator, _stateController, targetMask, rb, corruptSystem,
                prefabFactory, attackPoint);
            
            MileAttackInfo mileInfo = new MileAttackInfo(animator, _stateController, rb, attackPoint, targetMask);

            castSpell.Initialize(spellInfo, config.spellConfig);
            mileAttack.Initialize(mileInfo, config.attackConfig);
            
            _isInitialize = true;
        }

        private void Update()
        {
            if (!_isInitialize || !_stateController.CanAttack())
            {
                Debug.Log($"Can't attack: CanAttack {_stateController.CanAttack()} && Initialize {_isInitialize}");
                return;
            }
            
            if (castSpell.Cooldown > 0)
            {
                castSpell.MinesCooldown(Time.deltaTime);
            }

            if (mileAttack.Cooldown > 0)
            {
                mileAttack.MinesCooldown(Time.deltaTime);
            }
            
            if (Input.GetKeyDown(KeyCode.Q) && castSpell.Cooldown <= 0)
            {
                castSpell.Execute();
                return;
            }
            if (Input.GetMouseButtonDown(0) && mileAttack.Cooldown <= 0)
            {
                Debug.Log("Is Attack");
                mileAttack.Execute();
            }
        }
    }
}
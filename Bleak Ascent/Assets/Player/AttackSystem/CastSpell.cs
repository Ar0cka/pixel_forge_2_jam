using Player.CorruptedSystem;
using Player.Services;
using SoConfigs;
using UnityEngine;

namespace Player.AttackSystem
{
    public class CastSpell
    {
        private Animator _animator;
        private SpellConfig _spellConfig;
        private ICorrupted _corrupted;

        private StateController _stateController;
        
        private bool _isInitialized;
        
        public void Initialize(Animator animator, SpellConfig spellConfig, ICorrupted corrupted, StateController stateController)
        {
            _animator = animator;
            _spellConfig = spellConfig;
            _corrupted = corrupted;
            _stateController = stateController;
            
            _isInitialized = true;
        }

        public void Cast()
        {
            
        }
    }
}
using Player.CorruptedSystem;
using Player.Services;
using UnityEngine;

namespace Player.AttackSystem.CastSpellSystem
{
    public class SpellInfo : AttackInfo
    {
        public ICorrupted CorruptedSystem;
        public PrefabFactory PrefabFactory;
        public Transform StartSpellPoint;
        
        public SpellInfo(Animator animator, StateController stateController, LayerMask layerToAttack,
            Rigidbody2D rb, ICorrupted corruptedSystem, PrefabFactory prefabFactory, Transform startSpellPoint) : base(animator, stateController, rb, layerToAttack)
        {
            StartSpellPoint = startSpellPoint;
            CorruptedSystem = corruptedSystem;
            PrefabFactory = prefabFactory;
        }
    }
}
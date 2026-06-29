using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoConfigs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [field:SerializeField] public MoveConfig moveConfig;
        [field: SerializeField] public AttackConfig attackConfig;
        [field: SerializeField] public SpellConfig spellConfig;
    }

    [Serializable]
    public class MoveConfig
    {
        public float speed;
        public float runSpeed;
        public float attackSlowMultiplier;
        public float acceleration;
    }

    [Serializable]
    public class AttackConfig
    {
        public int attackDamage;
        public float cooldown;
        public float castTime;
        public string attackAnimationName;
    }

    [Serializable]
    public class SpellConfig
    {
        public GameObject spellPrefab;
        public float spellDamage;
        public float spellRadius;
        public float cooldown;
        public string spellAnimationName;
        public float castDelay;
        public List<SpellColor> spellColorVariations;
    }

    [Serializable]
    public class SpellColor
    {
        public Color color;
        public float corruptedNumber;
    }
}
using System;
using UnityEngine;

namespace SoConfigs
{
    [CreateAssetMenu(fileName = "healthConfig", menuName = "Actor/Health Config", order = 0)]
    public class HealthSO : ScriptableObject
    {
        [field:SerializeField] public HealthConfig config { get; private set; }
    }
    
    [Serializable]
    public class HealthConfig
    {
        public int maxHealth;
        public float healthRegenerationRate;
        public float regenerationDelay;
    }
}
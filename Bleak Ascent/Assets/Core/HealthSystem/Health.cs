using System;
using SoConfigs;
using UnityEngine;

namespace Core.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private HealthSO health;
        [SerializeField] private DeadAbstraction deadSystem;
        
        [HideInInspector] 
        public int CurrentHealth { get; private set; }

        private float _healthAmount;
        private float _regenerationTimer = 0f;
        
        private void Update()
        {
            if (_regenerationTimer >= 0)
            {
                _regenerationTimer -= Time.deltaTime;
                return;
            }
            
            Regeneration();
        }

        public void TakeDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                deadSystem.Die();
            }
        }

        public void SubscribeToDeadSystem(Action dieEvent)
        {
            deadSystem.OnDie += dieEvent;
        }

        
        private void Regeneration()
        {
            if (CurrentHealth >= health.config.maxHealth)
                return;

            _healthAmount += health.config.healthRegenerationRate;

            if (_healthAmount >= 1f)
            {
                CurrentHealth += 1;
                _healthAmount -= 1f;
            }
            
            _regenerationTimer += health.config.regenerationDelay;
        }
    }
}
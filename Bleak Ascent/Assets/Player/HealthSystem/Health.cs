using System;
using SoConfigs;
using UnityEngine;

namespace Player.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private HealthSO health;
        
        [HideInInspector] 
        public int CurrentHealth { get; private set; }

        private float _healthAmount;
        private float _regenerationTimer = 0f;

        public Action OnDead;
        
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
                Dead();
            }
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

        private void Dead()
        {
            OnDead?.Invoke();
        }
    }
}
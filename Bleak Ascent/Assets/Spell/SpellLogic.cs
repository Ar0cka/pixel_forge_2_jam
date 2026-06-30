using System;
using Core.HealthSystem;
using DG.Tweening;
using SoConfigs;
using UnityEngine;

namespace Spell
{
    public class SpellLogic : MonoBehaviour
    {
        [SerializeField] private float spellDamageDelay = 0.5f;
        [SerializeField] private float spellLifeTime = 10f;
        [SerializeField] private float rotatePerSec = 2f;

        [SerializeField] private PlayerConfig _playerConfig;
        
        private SpellConfig _spellConfig;
        private LayerMask _layerMask;
        private bool _isSpellActive;
        
        private float _delayTimer;
        private float _lifeTimeTimer;
        
        private Tween _rotateTween;

        private void Awake()
        {
            Initialize(_playerConfig.spellConfig, LayerMask.GetMask("Units"));
        }

        public void Initialize(SpellConfig spellConfig, LayerMask layerMask)
        {
            _spellConfig = spellConfig;
            _layerMask = layerMask;
            
            _lifeTimeTimer = spellLifeTime;
            
            SetAnimation();
            _isSpellActive = true;
        }

        private void Update()
        {
            if (!_isSpellActive)
                return;
            
            _lifeTimeTimer -= Time.deltaTime;

            if (_lifeTimeTimer <= 0)
            {
                _isSpellActive = false;
                _rotateTween?.Kill();
                Destroy(gameObject);
                return;
            }

            if (_delayTimer > 0)
            {
                _delayTimer -= Time.deltaTime;
                return;
            }
            
            Execute();
        }

        private void Execute()
        {
            Collider2D[] colliders = new Collider2D[10];
            
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _spellConfig.spellRadius,
                colliders, _layerMask);

            if (size < 0)
                return;

            for (int i = 0; i < size; i++)
            {
                if (colliders[i].gameObject.CompareTag("Unit"))
                {
                    var health = colliders[i].GetComponent<Health>();
                    health.TakeDamage((int)_spellConfig.spellDamage);
                }
            }

            _delayTimer = spellDamageDelay;
        }

        private void SetAnimation()
        {
            _rotateTween?.Kill();

            var duration = 360 / rotatePerSec;
            
            _rotateTween = transform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var pos = transform.position;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pos, _spellConfig.spellRadius);
        }
#endif
        
    }
}
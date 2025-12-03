using System.Collections;
using Domain.Combat;
using Infrastructure.ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Adapters
{
    public class EnemyAdapter : MonoBehaviour
    {
        [SerializeField] private CombatStatsSo initialStats;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float flashDuration =.1f;
        [SerializeField] private Color flashColor = Color.red;
        
        private CombatantEntity _entity;
        private Color _originalColor;
        private Coroutine _flashCoroutine;

        public ICombatant GetCombatantEntity() => _entity;

        public void Initialize(ICombatStatsSo stats)
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }

            if (spriteRenderer != null)
            {
                _originalColor = spriteRenderer.color;
            }

            if (stats != null)
            {
                _entity = new CombatantEntity(stats.ToDomainStats());
            }

            if (_entity != null)
            {
                _entity.OnDamageTaken += HandleVisualHit;
                _entity.OnDeath += HandleDeath;
            }
        }

        private void Awake()
        {
            Initialize(initialStats);
        }

        private void OnDestroy()
        {
            if (_entity != null)
            {
                _entity.OnDamageTaken -= HandleVisualHit;
                _entity.OnDeath -= HandleDeath;
            }
        }

        private void HandleDeath() => Destroy(gameObject);

        private void HandleVisualHit(float damage)
        {
            TriggerSpriteFlash();
        }

        private void TriggerSpriteFlash()
        {
            if (spriteRenderer == null) return;

            if (_flashCoroutine != null)
            {
                StopCoroutine(_flashCoroutine);
            }

            _flashCoroutine = StartCoroutine(FlashCoroutine());
        }

        private IEnumerator FlashCoroutine()
        {
            if (spriteRenderer == null) yield break;
            
            spriteRenderer.color = flashColor;
            
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = _originalColor;
            _flashCoroutine = null;
        }
    }
}
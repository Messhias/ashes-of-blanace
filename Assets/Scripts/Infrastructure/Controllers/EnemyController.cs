using Domain.Combat;
using Infrastructure.ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private CombatStatsSo initialStats;
        private CombatantEntity _entity;

        public ICombatant GetCombatantEntity() => _entity;

        private void Awake()
        {
            if (initialStats)
            {
                _entity = new CombatantEntity(initialStats.ToDomainStats());
            }

            if (_entity != null)
            {
                _entity.OnDamageTaken += HandleVisualHit;
                _entity.OnDeath += HandleDeath;
            }
        }

        private void HandleDeath() => Destroy(gameObject);

        private void HandleVisualHit(float damage)
        {
            TriggerSpriteFlash();
        }

        private void TriggerSpriteFlash()
        {
            // TODO: implement coroutine to blink in red and back to normal
        }
    }
}
using System;
using Application;
using Domain.Combat;
using UnityEngine;

namespace Infrastructure.Adapters
{
    public class EnemyController : MonoBehaviour
    {
        #region Editor

        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackCooldown = 1.5f;
        [SerializeField] private float detectionRange = 1.5f;

        #endregion

        #region Private

        private EnemyAdapter _enemyAdapter;
        private IAbstractAttackService _attackService;
        private Transform _playerTransform;
        private float _lastAttackTime;
        private bool _isPlayerInRange;

        #endregion

        private void Awake()
        {
            _enemyAdapter = GetComponent<EnemyAdapter>();
            _attackService = new BasicAttackService();
            _lastAttackTime = -attackCooldown;
        }

        private void Start()
        {
            var player = GameObject.FindWithTag("Player") ?? throw new Exception("Player not found");
            _playerTransform = player.transform;
        }

        private void Update()
        {
            if (_enemyAdapter == null)
            {
                return;
            }

            var entity = _enemyAdapter.GetCombatantEntity();
            if (entity == null || entity.IsDead)
            {
                return;
            }

            var distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
            _isPlayerInRange = distanceToPlayer <= detectionRange;

            if (_isPlayerInRange && distanceToPlayer <= attackRange)
            {
                TryAttackPlayer(entity, Time.time);
            }
        }

        private void TryAttackPlayer(ICombatant entity, float time)
        {
            if (time <= _lastAttackTime + attackCooldown) return;
            
            var playerAdapter = _playerTransform.GetComponent<PlayerAdapter>();

            if (playerAdapter == null) return;

            var playerEntity = playerAdapter.GetCombatantEntity();
            if (entity == null || entity.IsDead)
            {
                return;
            }

            var success = _attackService.Execute(entity, playerEntity, time);

            if (success)
            {
                _lastAttackTime = time;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
    }
}
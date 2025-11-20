using System;
using Application;
using Domain.Combat;
using UnityEngine;

namespace Infrastructure.Adapters
{
    public class AttackHitBox : MonoBehaviour
    {
        private IBasicAttackService _basicAttack;
        private ICombatant _entity;

        private void OnCollisionEnter(Collision other)
        {
            if (_basicAttack == null ||  _entity == null)
            {
                Debug.LogError("Attack hit box not initialized. Entity and basic attack is null");
                return;
            }
            
            if (other.gameObject.TryGetComponent<EnemyAdapter>(out var enemyController))
            {
                var target = enemyController.GetCombatantEntity();
                if (target != null)
                {
                    _basicAttack.Execute(_entity, target, Time.time);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_basicAttack == null ||  _entity == null)
            {
                Debug.LogError("Attack hit box not initialized. Entity and basic attack is null");
                return;
            }
            
            if (other.TryGetComponent<EnemyAdapter>(out var enemyController))
            {
                var target = enemyController.GetCombatantEntity();
                if (target != null)
                {
                    _basicAttack.Execute(_entity, target, Time.time);
                }
            }
        }

        public void SetBasicAttack(IBasicAttackService service)
        {
            _basicAttack = service;
        }

        public void SetEntity(ICombatant entity)
        {
            _entity = entity;
        }
    }
}
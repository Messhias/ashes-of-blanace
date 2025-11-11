using System;
using Application;
using Domain.Combat;
using UnityEngine;

namespace Infrastructure.Controllers
{
    public class PlayerAttackZone : MonoBehaviour
    {
        private IBasicAttackUseCase _basicAttack;
        private ICombatant _entity;


        private void OnTriggerEnter(Collider other)
        {
            if (_basicAttack == null ||  _entity == null)
            {
                Debug.LogError("Attack zone not initialized. Entity and basic attack is null");
                return;
            }
            
            if (other.TryGetComponent<EnemyController>(out var enemyController))
            {
                var target = enemyController.GetCombatantEntity();
                _basicAttack.Execute(_entity, target, Time.time);
                
                // TODO:
                // add the impact attack sound.
            }
        }
    }
}
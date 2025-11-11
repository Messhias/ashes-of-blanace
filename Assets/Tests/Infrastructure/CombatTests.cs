using System.Collections;
using Application;
using Domain.Combat;
using Infrastructure.Controllers;
using Infrastructure.ScriptableObjects;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.Infrastructure
{
    public class CombatTests
    {
        private PlayerAttackZone _attackZone;
        private EnemyController _enemyController;
        private GameObject _enemy;
        private GameObject _attack;
        private BasicAttackUseCase _basicAttack;
        private ICombatant _playerEntity;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            _enemy = new GameObject("Enemy");
            _enemy.AddComponent<Rigidbody>().isKinematic = true;
            _enemy.AddComponent<BoxCollider>().isTrigger = true;
            _enemyController = _enemy.AddComponent<EnemyController>();

            var enemyStats = ScriptableObject.CreateInstance<CombatStatsSo>();
            enemyStats.MaxHp = 1f;
            
            yield return null;
        }
    }
}
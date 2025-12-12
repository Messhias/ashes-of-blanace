using Application;
using Domain.Combat;
using Extensions;
using NUnit.Framework;

namespace Tests
{
    public class CoreLoopIntegrationTests
    {
        private IAbstractAttackService _attackService;
        private IDodgeService _dodgeService;
        private ICombatant _player;
        private ICombatant _enemy;

        [SetUp]
        public void Setup()
        {
            var enemyStats = new CombatStats
            {
                MaxHP = 30f,
                Attack = 5,
                Defense = 15,
                MaxMP = 0f,
            };

            var playerStats = new CombatStats
            {
                MaxHP = 100f,
                Attack = 12,
                Defense = 10,
                MaxMP = 40f,
                Intelligence = 5,
            };

            _enemy = new CombatantEntity(enemyStats);
            _player = new CombatantEntity(playerStats);

            _attackService = new BasicAttackService();
            _dodgeService = new DodgeService();
        }

        [Test]
        public void CoreLoop_EnemyAttackPlayer_PlayerAttackWithMitigation_PlayerDodges()
        {
            // arrange
            var currentTime = 0f;

            // act
            _enemy.Attack(_player, currentTime, _attackService);

            // assert
            // 100 - (5) = 95.
            // 10% = .5 = 95.5f
            Assert.AreEqual(95.5f, _player.CurrentHP, 0.1f,
                $"Player HP is wrong, should be 95.5f, but it is {_player.CurrentHP}");

            // arrange
            currentTime = 1f;

            // act
            _player.Attack(_enemy, currentTime, _attackService);
            var expectedEnemyHp = 30f - 12f * (1f - 15 / 100f);

            // assert
            Assert.AreEqual(expectedEnemyHp, _enemy.CurrentHP, 0.1f,
                $"Enemy HP is wrong, should be 95.5f, but it is {_enemy.CurrentHP}");

            // arrange
            currentTime = 2f;

            // act
            var dodgeSuccess = _dodgeService.Execute(_player, currentTime);

            // assert
            Assert.IsTrue(dodgeSuccess);
            Assert.AreEqual(95.5f, _player.CurrentHP, 0.1f,
                $"Player HP is wrong, should be 95.5f, but it is {_player.CurrentHP}");

            // arrange
            currentTime = 2.1f;
            // act
            _enemy.Attack(_player, currentTime, _attackService);

            // assert
            Assert.AreEqual(95.5f, _player.CurrentHP, 0.1f,
                $"Player HP is wrong, should be 95.5f, but it is {_player.CurrentHP}. Player is in invincible frames");
            
            // arrange
            currentTime = 3f;
            _player.UpdateInvincibility(currentTime);
            
            Assert.IsFalse(_player.IsInvincible);
        }
    }
}
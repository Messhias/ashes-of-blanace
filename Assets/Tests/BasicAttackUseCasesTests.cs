using Application;
using Domain.Combat;
using NUnit.Framework;

namespace Tests
{
    public class BasicAttackUseCasesTests
    {
        private IBasicAttackService _service;

        [SetUp]
        public void Setup()
        {
            _service = new BasicAttackService();
        }
        
        [Test]
        public void Execute_AppliesCorrectDamageAndSetsCooldown()
        {
            // arrange
            var attacker = MockCombatant.CreateCombatant(new CombatStats
            {
                Attack = 12,
                Defense = 10,
            });
            var target = MockCombatant.CreateCombatant(new CombatStats
            {
                Defense = 0,
                MaxHP = 50f,
            });
            
            const float expectedTargetHp = 38f;
            const float currentTime = 5.0f;
            
            // act
            var success = _service.Execute(attacker, target, currentTime);
            
            Assert.IsTrue(success, "Basic attack not succeeded.");
            Assert.AreEqual(expectedTargetHp, target.CurrentHP, "Target HP is incorrect.");
            Assert.AreEqual(currentTime + 0.5f, attacker.LastActionTime, "Cooldown time was not set correctly.");
        }

        [Test]
        public void Execute_ReturnsFalse_WhenOnCooldown()
        {
            // arrange
            var attacker = MockCombatant.CreateCombatant(new CombatStats
            {
                Attack = 12
            });
            var target = MockCombatant.CreateCombatant(new CombatStats
            {
                MaxHP = 50f
            });

            attacker.LastActionTime = 10.0f;
            const float currentTime = 9.0f;
            var initialTargetHp = target.CurrentHP;
            
            // act
            var success = _service.Execute(attacker, target, currentTime);
            
            // assert
            Assert.IsFalse(success, "Attack should fail when on cooldown.");
            Assert.AreEqual(initialTargetHp, target.CurrentHP, "Target HP is incorrect.");
            Assert.AreEqual(10.0f, attacker.LastActionTime, "Cooldown time was not set correctly.");
        }
    }
}
using Application;
using Domain.Combat;
using NUnit.Framework;

namespace Tests
{
    public class BasicAttackUseCasesTests
    {
        private IBasicAttackUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            _useCase = new BasicAttackUseCase();
        }
        
        
        [Test]
        public void Execute_AppliesCorrectDamageAndSetsCooldown()
        {
            // arrange
            var attackerStats = new CombatStats
            {
                Attack = 12,
                Defense = 10,
            };
            var targetStats = new CombatStats
            {
                Defense = 0,
                MaxHP = 50f,
            };
            var attacker = new CombatantEntity(attackerStats);
            var target = new CombatantEntity(targetStats);
            
            var expectedTargetHp = 38f;
            var currentTime = 5.0f;
            
            // act
            var success = _useCase.Execute(attacker, target, currentTime);
            
            Assert.IsTrue(success, "Basic attack not succeeded.");
            Assert.AreEqual(expectedTargetHp, target.CurrentHP, "Target HP is incorrect.");
            Assert.AreEqual(currentTime + 0.5f, attacker.LastActionTime, "Cooldown time was not set correctly.");
        }
    }
}
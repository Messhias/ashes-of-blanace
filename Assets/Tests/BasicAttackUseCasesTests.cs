using Application;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class BasicAttackUseCasesTests
    {
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
            var attacker = new Hero(attackerStats);
            var target = new Hero(targetStats);
            
            var expectedTargetHp = 38f;
            var currentTime = 5.0f;

            var useCase = new BasicAttackUseCase();
            
            // act
            var success = useCase.Execute(attacker, target, currentTime);
            
            Assert.IsTrue(success, "Basic attack not succeeded.");
            Assert.AreEqual(expectedTargetHp, target.CurrentHP, "Target HP is incorrect.");
            Assert.AreEqual(currentTime + 0.5f, attacker.LastActionTime, "Cooldown time was not set correctly.");
        }
    }
}
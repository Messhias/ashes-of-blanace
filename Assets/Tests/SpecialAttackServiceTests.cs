using Application;
using Domain.Combat;
using NUnit.Framework;

namespace Tests
{
    public class SpecialAttackServiceTests
    {
        private ISpecialAttackService _service;

        [SetUp]
        public void Setup()
        {
            _service = new SpecialAttackService();
        }

        [Test]
        public void Execute_AppliesCorrectDamageAndSetsCooldown()
        {
            // arrange
            var attacker = MockCombatant.CreateCombatant(new CombatStats());
            var target = MockCombatant.CreateCombatant(new CombatStats
            {
                Defense = 0,
                MaxHP = 50f,
            });
            // Raw damage = 5 * 2 = 10
            const float expectedTargetHp = 40f;
            const float expectedMp = 15f;
            const float currentTime = 5.0f;

            // act
            var success = _service.Execute(attacker, target, currentTime);

            // assert
            Assert.IsTrue(success);
            Assert.AreEqual(target.CurrentHP, expectedTargetHp, 0.1f);
            Assert.AreEqual(attacker.CurrentMP, expectedMp);
            Assert.AreEqual(currentTime + 8.0f, attacker.LastActionTime);
        }
        
        [TestCase(12, 40f, 10, 50f, 10.0f, 40f)]
        [TestCase(12, 40f, 10, 50f, 10.0f, 0f)]
        public void Execute_ReturnFalse_WhenOnCooldownOrInsufficientMp(int atkAttacker, float hpAttacker,
            int defenseAttacker, float hpTarget, float lastActionTime, float attackerMp)
        {
            // arrange
            var attacker = MockCombatant.CreateCombatant(new CombatStats
            {
                Attack = atkAttacker,
                MaxHP = hpAttacker,
                Defense = defenseAttacker,
                MaxMP = attackerMp
            });
            var target = MockCombatant.CreateCombatant(new CombatStats
            {
                MaxHP = hpTarget,
            });
            attacker.LastActionTime = lastActionTime;
            const float currentTime = 9.0f;
            var initialMp = attacker.CurrentMP;

            // act
            var success = _service.Execute(attacker, target, currentTime);

            // assert
            Assert.IsFalse(success);
            Assert.AreEqual(hpAttacker, attacker.CurrentHP, 0.1f);
            Assert.AreEqual(initialMp, attacker.CurrentMP, 0.1f);
            Assert.AreEqual(lastActionTime, attacker.LastActionTime, 0.1f);
        }

        [Test]
        public void Execute_AppliesCorrectDamageWithMitigation()
        {
            // arrange
            var attacker = MockCombatant.CreateCombatant(new CombatStats());
            var target = MockCombatant.CreateCombatant(new CombatStats
            {
                Defense = 10,
                MaxHP = 100f,
            });
            
            // Raw damage = 5 * 2 = 10
            // Final damage = 10 * (1-10/100) = 10 * .9 = 9f
            const float expectedHp = 91; // 100 - 9
            const float currentTime = 5.0f;
            
            // act
            var success = _service.Execute(attacker, target, currentTime);
            
            // assert
            Assert.IsTrue(success);
            Assert.AreEqual(expectedHp, target.CurrentHP, 0.1f);
        }
    }
}
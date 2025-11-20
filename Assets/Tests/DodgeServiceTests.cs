using Application;
using Domain.Combat;
using NUnit.Framework;

namespace Tests
{
    public class DodgeServiceTests
    {
        private IDodgeService _service;

        [SetUp]
        public void Setup()
        {
            _service = new DodgeService();
        }
        
        [Test]
        public void Execute_DodgeSucceeds_WhenMpIsSufficient()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats { MaxMP = 40f, Intelligence = 5 });

            const float expectedMp = 35.5f;
            
            // act
            var success = _service.Execute(hero, 10.0f);
            
            // assert 
            Assert.IsTrue(success, "Dodge should succeed.");
            Assert.AreEqual(expectedMp, hero.CurrentMP, "MP cost was calculated incorrectly.");
            
            Assert.AreEqual(10.5f, hero.LastActionTime, "Cooldown was not set correctly");
        }

        [Test]
        public void Execute_DodgeFails_WhenMpIsInsufficient()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats { MaxMP = 4f, Intelligence = 5 });

            // act
            var success = _service.Execute(hero, 10.0f);
            
            Assert.IsFalse(success, "Dodge should fail due to insufficient MP.");
            Assert.AreEqual(4f, hero.CurrentMP, "MP should not be spent if dodge fails.");
        }

        [Test]
        public void Execute_ReturnFalse_WhenCooldown()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats { MaxMP = 4f, Intelligence = 5 });
            hero.LastActionTime = 10.0f;
            
            const float currentTime = 9.0f;
            
            // act
            var success = _service.Execute(hero, currentTime);
            
            // assert
            Assert.IsFalse(success, "Attack should fail when on cooldown.");
            Assert.AreEqual(10.0f, hero.LastActionTime, "Cooldown time was not set correctly.");
        }

        [Test]
        public void Execute_CalculateCorrectMpCost_WithIntelligenceReduction()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats
            {
                MaxMP = 100f,
                Intelligence = 10,
            });
            const float expectedMp = 96.0f;

            // act
            var success = _service.Execute(hero, 0f);
            
            // arrange
            Assert.IsTrue(success, "Dodge should succeed.");
            Assert.AreEqual(expectedMp, hero.CurrentMP, "MP cost was calculated incorrectly.");
        }
    }
}
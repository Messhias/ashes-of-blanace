using Application;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class DodgeUseCaseTests
    {
        [Test]
        public void Execute_DodgeSucceeds_WhenMpIsSufficient()
        {
            // arrange
            var stats = new CombatStats { MaxMP = 40f, Intelligence = 5 };
            var hero = new Hero(stats);

            var expectedMp = 35.5f;

            var useCase = new DodgeUseCase();
            
            // act
            var success = useCase.Execute(hero, 10.0f);
            
            // assert 
            Assert.IsTrue(success, "Dodge should succeed.");
            Assert.AreEqual(expectedMp, hero.CurrentMP, "MP cost was calculated incorrectly.");
            
            Assert.AreEqual(10.5f, hero.LastActionTime, "Cooldown was not set correctly");
        }

        [Test]
        public void Execute_DodgeFails_WhenMpIsInsufficient()
        {
            // arrange
            var stats = new CombatStats { MaxMP = 4f, Intelligence = 5 };
            var hero = new Hero(stats);

            var useCase = new DodgeUseCase();
            
            // act
            var success = useCase.Execute(hero, 10.0f);
            
            Assert.IsFalse(success, "Dodge should fail due to insufficient MP.");
            Assert.AreEqual(4f, hero.CurrentMP, "MP should not be spent if dodge fails.");
        }
    }
}
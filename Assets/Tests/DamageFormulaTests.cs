using Domain.Combat;
using NUnit.Framework;

namespace Tests
{
    public class DamageFormulaTests
    {
        [Test]
        public void CalculateDamage_AppliesCorrect10PercentMitigation()
        {
            // arrange
            var rawDamage = 100f;
            var defense = 10;
            var expectedFinalDamage = 90f;

            // act
            var actualDamage = DamageFormula.CalculateDamage(rawDamage, defense);

            // assert
            Assert.AreEqual(expectedFinalDamage, actualDamage);
        }

        [TestCase(50f, 0, 50f)]
        [TestCase(100f, 70, 30f)]
        public void CalculateDamage_AppliesNotMitigation_ZeroDefense(float rawDamage, int defense, float expectedFinalDamage)
        {
            // act
            var actualDamage = DamageFormula.CalculateDamage(rawDamage, defense);

            // assert
            Assert.AreEqual(expectedFinalDamage, actualDamage, 0.001f);
        }
    }
}

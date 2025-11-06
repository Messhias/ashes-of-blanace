using Assets.Scripts.Domain;
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

        [Test]
        public void CalculateDamage_AppliesNotMitigation_ZeroDefense()
        {
            // arrange
            var rawDamage = 50f;
            var defense = 0;
            var expectedFinalDamage = 50f;

            // act
            var actualDamage = DamageFormula.CalculateDamage(rawDamage, defense);

            // assert
            Assert.AreEqual(expectedFinalDamage, actualDamage);
        }
    }
}

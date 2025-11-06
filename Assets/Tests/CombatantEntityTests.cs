using Domain;
using Domain.Combat;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CombatantEntityTests
    {
        [Test]
        public void Hero_AppliesDamageCorrectly_ReducesHP()
        {
            // arrange
            var initialStats = new CombatStats { Defense = 10, MaxHP = 100f, MpRegenPerSecond = 5f };
            var hero = new CombatantEntity(initialStats);

            const float rawDamage = 20f;
            const float expectedHp = 82f; // 100 - 18

            // act
            hero.ApplyDamage(rawDamage);

            // assert
            Assert.AreEqual(expectedHp, hero.CurrentHP);
        }

        [Test]
        public void Hero_HPDoesNotGoBelowZero_OnLethalDamage()
        {
            // arrange
            var initialStats = new CombatStats { Defense = 10, MaxHP = 100f };
            var hero = new CombatantEntity(initialStats);

            var rawDamage = Random.Range(1000f, 2000f);

            // act
            hero.ApplyDamage(rawDamage);

            // assert
            Assert.AreEqual(0f, hero.CurrentHP);
        }

        [Test]
        public void Hero_RestoreMP_CannotExceedMaxMP()
        {
            // arrange
            var initialStats = new CombatStats { MaxMP = 40f };
            var hero = new CombatantEntity(initialStats);

            hero.TrySpendMp(10f);

            // act
            hero.RestoreMp(1000f);

            // assert
            Assert.AreEqual(initialStats.MaxMP, hero.CurrentMP);
        }

        [Test]
        public void Hero_TrySpendMP_FailsWhenInsufficientMP()
        {
            // arrange
            var initialStats = new CombatStats { MaxMP = 40f };
            var hero = new CombatantEntity(initialStats);
            var largeCost = 50f;

            // act
            var success = hero.TrySpendMp(largeCost);

            // assert
            Assert.IsFalse(success);
            Assert.AreEqual(hero.MaxMP, hero.CurrentMP);
        }
    }
}
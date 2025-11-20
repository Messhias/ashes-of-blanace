using Domain.Combat;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Tests
{
    public class CombatantEntityTests
    {
        [Test]
        public void Hero_AppliesDamageCorrectly_ReducesHP()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats
                { Defense = 10, MaxHP = 100f, MpRegenPerSecond = 5f });

            const float rawDamage = 20f;
            const float expectedHp = 82f;

            // act
            hero.ApplyDamage(rawDamage);

            // assert
            Assert.AreEqual(expectedHp, hero.CurrentHP);
        }

        [Test]
        public void Hero_HPDoesNotGoBelowZero_OnLethalDamage()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats { Defense = 10, MaxHP = 100f });

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
            var hero = MockCombatant.CreateCombatant(new CombatStats { MaxMP = 40f });

            hero.TrySpendMp(10f);

            // act
            hero.RestoreMp(1000f);

            // assert
            Assert.AreEqual(new CombatStats { MaxMP = 40f }.MaxMP, hero.CurrentMP);
        }

        [Test]
        public void Hero_TrySpendMP_FailsWhenInsufficientMP()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats { MaxMP = 40f });
            const float largeCost = 50f;

            // act
            var success = hero.TrySpendMp(largeCost);

            // assert
            Assert.IsFalse(success);
            Assert.AreEqual(hero.MaxMP, hero.CurrentMP);
        }

        [Test]
        public void ApplyDamage_TriggersOnDamageTakenEvent()
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats
            {
                MaxHP = 100f,
                Defense = 0
            });
            float? damageReceived = null;
            const float expectedDamage = 25f;
            
            hero.OnDamageTaken += damage => damageReceived = damage;
            
            //act
            hero.ApplyDamage(expectedDamage);
            
            // assert
            Assert.IsTrue(damageReceived.HasValue);
            Assert.AreEqual(expectedDamage, damageReceived.Value);
        }

        [TestCase(100f, 0, 100f)]
        [TestCase(100f, 0, 1100f)]
        public void ApplyDamage_TriggersOnDeathEvent_WhenHPReachesZero(float hp, int defense, float damage)
        {
            // arrange
            var hero = MockCombatant.CreateCombatant(new CombatStats
            {
                MaxHP = hp,
                Defense = defense
            });
            var deathEventIsTriggered = false;
            hero.OnDeath += () => deathEventIsTriggered = true;
            
            // act
            hero.ApplyDamage(damage);
            
            // assert
            Assert.IsTrue(deathEventIsTriggered);
            Assert.IsTrue(hero.IsDead);
            Assert.AreEqual(0f,  hero.CurrentHP);
        }
    }
}
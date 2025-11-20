using System;

namespace Domain.Combat
{
    public class CombatantEntity : ICombatant
    {
        #region HP props
        public float CurrentHP { get; private set; }
        public float MaxHP { get; }
        public int Defense { get; }

        #endregion

        #region MP props

        public float CurrentMP { get; private set; }
        public float MaxMP { get; }
        public float MpRegenPerSecond { get; set; }

        #endregion

        public float LastActionTime { get; set; }
        public int Attack { get; }
        public int Intelligence { get; }
        public bool IsDead { get; private set; }
        public event Action<float> OnDamageTaken;
        public event Action OnDeath;
        
        public CombatantEntity(ICombatStats combatStats)
        {
            MaxHP = combatStats.MaxHP;
            CurrentHP = combatStats.MaxHP;
            Defense = combatStats.Defense;

            Attack = combatStats.Attack;
            Intelligence = combatStats.Intelligence;

            MaxMP = combatStats.MaxMP;
            CurrentMP = combatStats.MaxMP;
            MpRegenPerSecond = combatStats.MpRegenPerSecond;

            IsDead = false;
        }
        
        public void ApplyDamage(float damage)
        {
            if (IsDead)
            {
                return;
            }
            
            var finalDamage = DamageFormula.CalculateDamage(damage, Defense);

            CurrentHP -= finalDamage;
            
            OnDamageTaken?.Invoke(damage);
            
            if (!(CurrentHP <= 0)) return;
            
            CurrentHP = 0;
            IsDead = true;
            
            OnDeath?.Invoke();
        }

        public void RestoreMp(float mp)
        {
            CurrentMP += mp;
            if (CurrentMP > MaxMP)
            {
                CurrentMP = MaxMP;
            }
        }

        public bool TrySpendMp(float cost)
        {
            if (!(CurrentMP >= cost)) return false;

            CurrentMP -= cost;
            return true;
        }
    }
}
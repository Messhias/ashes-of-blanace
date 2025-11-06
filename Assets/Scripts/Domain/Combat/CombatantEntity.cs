namespace Domain.Combat
{
    public class CombatantEntity : ICombatant
    {
        #region HP props

        public float CurrentHP { get; private set; }

        // ReSharper disable once InconsistentNaming
        public float MaxHP { get; }
        public int Defense { get; }

        #endregion

        #region MP props

        // ReSharper disable once InconsistentNaming
        public float CurrentMP { get; private set; }

        // ReSharper disable once InconsistentNaming
        public float MaxMP { get; }
        public float MpRegenPerSecond { get; }

        #endregion

        public float LastActionTime { get; set; }
        public int Attack { get; }
        public int Intelligence { get; }

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
        }


        public void ApplyDamage(float damage)
        {
            var finalDamage = DamageFormula.CalculateDamage(damage, Defense);

            CurrentHP -= finalDamage;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
            }
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
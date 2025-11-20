using System;

namespace Domain.Combat
{
    public interface ICombatant
    {
        // ReSharper disable once InconsistentNaming
        float CurrentHP { get; }
        // ReSharper disable once InconsistentNaming
        float MaxHP { get; }
        int Defense { get; }
        // ReSharper disable once InconsistentNaming
        float CurrentMP { get; }
        // ReSharper disable once InconsistentNaming
        float MaxMP { get; }
        float MpRegenPerSecond { get; set; }
        float LastActionTime { get; set; }
        int Attack { get; }
        int Intelligence { get; }
        bool IsDead { get; }
        void ApplyDamage(float damage);
        void RestoreMp(float mp);
        bool TrySpendMp(float cost);
        event Action<float> OnDamageTaken;
        event Action OnDeath;
    }
}
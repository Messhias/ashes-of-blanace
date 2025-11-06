namespace Domain
{
    public interface ICombatant
    {
        // ReSharper disable once InconsistentNaming
        float CurrentHP { get; }
        // ReSharper disable once InconsistentNaming
        float MaxHP { get; }
        int Defense { get; }
        float LastActionTime { get; set; }
        int Attack { get; }
        int Intelligence { get; }
        void ApplyDamage(float damage);
        bool TrySpendMp(float amount);
    }
}
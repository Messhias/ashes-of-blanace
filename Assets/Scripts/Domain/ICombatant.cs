namespace Domain
{
    public interface ICombatant
    {
        // ReSharper disable once InconsistentNaming
        float CurrentHP { get; }
        // ReSharper disable once InconsistentNaming
        float MaxHP { get; }
        int Defense { get; }
        void ApplyDamage(float damage);
    }
}
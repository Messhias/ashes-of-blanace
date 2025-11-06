namespace Domain.Combat
{
    public interface ICombatStats
    {
        // ReSharper disable once InconsistentNaming   
        float MaxHP { get; set; }
        // ReSharper disable once InconsistentNaming
        float MaxMP { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Intelligence { get; set; }
        float MpRegenPerSecond { get; set; }
    }

    public class CombatStats : ICombatStats
    {
        public float MaxHP { get; set; } = 100f;
        public float MaxMP { get; set; } = 40f;
        public int Attack { get; set; } = 12;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 5;
        public float MpRegenPerSecond { get; set; } = 5f;
    }
}
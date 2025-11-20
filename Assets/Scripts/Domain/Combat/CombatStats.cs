namespace Domain.Combat
{
    public interface ICombatStats
    {
        // ReSharper disable once InconsistentNaming   
        float CurrentHP { get; set; }
        // ReSharper disable once InconsistentNaming   
        float MaxHP { get; set; }
        // ReSharper disable once InconsistentNaming
        float MaxMP { get; set; }
        // ReSharper disable once InconsistentNaming
        float CurrentMP { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Intelligence { get; set; }
        float MpRegenPerSecond { get; set; }
        // ReSharper disable once InconsistentNaming
        float BaseXPToLevel{get;}
        // ReSharper disable once InconsistentNaming
        int StatPoints { get; }
    }

    public class CombatStats : ICombatStats
    {
        public float CurrentHP { get; set; } = 100f;
        public float MaxHP { get; set; } = 100f;
        public float MaxMP { get; set; } = 40f;
        public float CurrentMP { get; set; }
        public int Attack { get; set; } = 12;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 5;
        public float MpRegenPerSecond { get; set; } = 5f;
        public float BaseXPToLevel { get; set; } = 0f;
        public int StatPoints { get; set; } = 0;
    }
}
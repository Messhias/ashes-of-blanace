using Domain.Combat;

namespace Tests
{
    public static class MockCombatant
    {
        public static ICombatant CreateCombatant(CombatStats combatStats) => new CombatantEntity(combatStats);
    }
}
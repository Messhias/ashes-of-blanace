using Domain.Combat;

namespace Infrastructure.ScriptableObjects
{
    public interface ICombatStatsSo
    {
        CombatStats ToDomainStats();
    }
}
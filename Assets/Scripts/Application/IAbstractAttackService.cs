using Domain.Combat;

namespace Application
{
    public interface IAbstractAttackService
    {
        bool Execute(ICombatant attacker, ICombatant target, float currentTime);
    }
}
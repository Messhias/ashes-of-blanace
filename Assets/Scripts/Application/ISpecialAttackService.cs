using Domain.Combat;

namespace Application
{
    public interface ISpecialAttackService
    {
        bool Execute(ICombatant attacker, ICombatant target, float currentTime);
    }
}
using Domain.Combat;

namespace Application
{
    public interface IStrongAttackService
    {
        bool Execute(ICombatant attacker, ICombatant target, float currentTime);
    }
}
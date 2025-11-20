using Domain.Combat;

namespace Application
{
    public interface IBasicAttackService
    {
        bool Execute(ICombatant attacker, ICombatant target, float currentTime);
    }
}
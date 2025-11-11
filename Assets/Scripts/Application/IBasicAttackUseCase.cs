using Domain.Combat;

namespace Application
{
    public interface IBasicAttackUseCase
    {
        bool Execute(ICombatant attacker, ICombatant target, float currentTime);
    }
}
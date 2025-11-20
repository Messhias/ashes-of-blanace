using Domain.Combat;

namespace Application
{
    public interface IDodgeService
    {
        bool Execute(ICombatant caster, float currentTime);
    }
}
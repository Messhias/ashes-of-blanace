using Application;
using Domain.Combat;

namespace Extensions
{
    public static class CombatantEntityExtensions
    {
        public static void Attack(this ICombatant attacker, ICombatant target, float time,
            IAbstractAttackService service)
        {
            service.Execute(attacker, target, time);
        }
    }
}
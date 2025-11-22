using Domain.Combat;

namespace Application
{
    public class SpecialAttackService : AbstractAttackService
    {
        public SpecialAttackService()
        {
            SetCooldown(8.0f);
            SetDamageMultiplier(2f);
            SetMpCost(25f);
        }

        public override bool Execute(ICombatant attacker, ICombatant target, float currentTime)
        {
            if (currentTime < attacker.LastActionTime) return false;

            if (!attacker.TrySpendMp(MpCost)) return false;

            var rawDamage = attacker.Intelligence * DamageMultiplier;
            target.ApplyDamage(rawDamage);

            attacker.LastActionTime = currentTime + Cooldown;
            NotifyAttackExecuted(attacker, target);

            return true;
        }
    }
}
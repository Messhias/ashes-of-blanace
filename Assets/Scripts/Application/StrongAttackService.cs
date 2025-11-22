using Domain.Combat;

namespace Application
{
    public class StrongAttackService : AbstractAttackService
    {
        public StrongAttackService()
        {
            SetCooldown(3.0f);
            SetDamageMultiplier(1.8f);
            SetMpCost(10f);
        }

        public override bool Execute(ICombatant attacker, ICombatant target, float currentTime)
        {
            if (currentTime < attacker.LastActionTime) return false;

            if (!attacker.TrySpendMp(MpCost)) return false;

            var rawDamage = attacker.Attack * DamageMultiplier;
            target.ApplyDamage(rawDamage);

            attacker.LastActionTime = currentTime + Cooldown;

            return true;
        }
    }
}
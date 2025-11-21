using Domain.Combat;

namespace Application
{
    public class StrongAttackService : IStrongAttackService
    {
        private const float Cooldown = 3.0f;
        private const float DamageMultiplier = 1.8f;
        private const float MpCost = 10f;

        public bool Execute(ICombatant attacker, ICombatant target, float currentTime)
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
using Domain.Combat;

namespace Application
{
    public class SpecialAttackService : ISpecialAttackService
    {
        private const float Cooldown = 8.0f;
        private const float DamageMultiplier = 2f;
        private const float MpCost = 25f;
            
        public bool Execute(ICombatant attacker, ICombatant target, float currentTime)
        {
            if (currentTime < attacker.LastActionTime) return false;

            if (!attacker.TrySpendMp(MpCost)) return false;

            var rawDamage = attacker.Intelligence * DamageMultiplier;
            target.ApplyDamage(rawDamage);
            
            attacker.LastActionTime = currentTime + Cooldown;

            return true;
        }
    }
}
using Domain;
using Domain.Combat;

namespace Application
{
    public class BasicAttackUseCase
    {
        private const float Cooldown = 0.5f;
        private const float DamageMultiplier = 1.0f;

        public bool Execute(ICombatant attacker, ICombatant target, float currentTime)
        {
            if (currentTime < attacker.LastActionTime)
            {
                return false;
            }

            var rawDamage = attacker.Attack * DamageMultiplier;
            target.ApplyDamage(rawDamage);


            attacker.LastActionTime = currentTime + Cooldown;
            
            return true;
        }
    }
}
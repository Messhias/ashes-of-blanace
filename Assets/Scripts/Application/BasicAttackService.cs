using Domain.Combat;

namespace Application
{
    public class BasicAttackService: AbstractAttackService
    {
        public override bool Execute(ICombatant attacker, ICombatant target, float currentTime)
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
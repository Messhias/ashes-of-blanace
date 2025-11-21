using Domain.Combat;
using UnityEngine;

namespace Application
{
    public class DodgeService : IDodgeService
    {
        private const float BaseCost = 5.0f;
        private const float IntReductionFactor = 0.1f;
        private const float Cooldown = 0.5f;
        
        public bool Execute(ICombatant caster, float currentTime)
        {
            var mpReduction = caster.Intelligence * IntReductionFactor;
            var finalCost = Mathf.Max(0f, BaseCost - mpReduction);

            if (currentTime < caster.LastActionTime)
            {
                return false;
            }

            if (!caster.TrySpendMp(finalCost)) return false;
            
            caster.LastActionTime = currentTime + Cooldown;
            
            return true;
        }
    }
}
using Domain;
using Domain.Combat;

namespace Application
{
    public class DodgeUseCase
    {
        private const float BaseCost = 5.0f;
        private const float IntReductionFactor = 0.1f;
        private const float Cooldown = 0.5f;
        
        public bool Execute(ICombatant caster, float currentTime)
        {
            var mpReduction = caster.Intelligence * IntReductionFactor;
            var finalCost = BaseCost - mpReduction;

            if (currentTime < caster.LastActionTime)
            {
                return false;
            }

            if (!caster.TrySpendMp((finalCost))) return false;
            
            caster.LastActionTime = currentTime + Cooldown;
            
            return true;
        }
    }
}
namespace Assets.Scripts.Domain
{
    public static class DamageFormula
    {
        /// <summary>
        /// Calculates final damage after apply the mitigation from target's defense.
        /// Formula: Final Damage = Raw Damage * (1 - DEF / 100)
        /// </summary>
        /// <param name="rawDamage"></param>
        /// <param name="targetDefense"></param>
        /// <returns></returns>
        public static float CalculateDamage(float rawDamage, float targetDefense)
        {
            if (targetDefense <= 0)
            {
                return rawDamage;
            }
            
            var mitigationPercentage = targetDefense / 100f;
            
            // Ensuring the mitigation doesn't go bellow 0 (no healing from defense)
            var defenseMultiplier = 1f - mitigationPercentage;
            
            return rawDamage * defenseMultiplier;
        }
    }
}
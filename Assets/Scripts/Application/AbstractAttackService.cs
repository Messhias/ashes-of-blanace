using System;
using Domain.Combat;

namespace Application
{
    public abstract class AbstractAttackService : IAbstractAttackService
    {
        internal float Cooldown = 0.5f;
        internal float DamageMultiplier = 1.0f;
        internal float MpCost;
        public abstract bool Execute(ICombatant attacker, ICombatant target, float currentTime);
        public event Action<ICombatant, ICombatant> OnAttackExecuted;


        internal void SetCooldown(float value)
        {
            Cooldown = value;
        }

        internal void SetDamageMultiplier(float value)
        {
            DamageMultiplier = value;
        }

        internal void SetMpCost(float value)
        {
            MpCost = value;
        }

        protected void NotifyAttackExecuted(ICombatant attacker, ICombatant target)
        {
            OnAttackExecuted?.Invoke(attacker, target);
        }
    }
}
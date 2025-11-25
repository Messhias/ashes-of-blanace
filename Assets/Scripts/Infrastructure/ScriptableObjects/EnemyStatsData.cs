// Infrastructure/ScriptableObjects/EnemyStatsData.cs

using Domain.Combat;
using UnityEngine;

namespace Infrastructure.ScriptableObjects
{
    // Permite criar o ScriptableObject via menu da Unity
    [CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Stats/Enemy Stats")]
    public class EnemyStatsData : ScriptableObject
    {
        
        [Header("Combate Básico")]
        [SerializeField]
        private float initialHp = 50f;
        [SerializeField]
        private float initialMp;
        [SerializeField]
        private int initialAttack = 10;
        [SerializeField]
        private int initialDefense = 5;
        [SerializeField]
        private int initialIntelligence = 5;
        
        [Header("Drop e Progressão")]
        [SerializeField]
        private float xpOnDeath = 50f;
        
        public CombatStats ToDomainStats() => new()
        {
            MaxHP = initialHp,
            CurrentHP = initialHp,
            MaxMP = initialMp,
            CurrentMP = initialMp,
            Attack = initialAttack,
            Defense = initialDefense,
            Intelligence = initialIntelligence,
            
            // ENEMY DOESN'T NEED IT, SO WE SET UP AUTOMATICALLY TO 0
            MpRegenPerSecond = 0f, 
            BaseXPToLevel = 0f,
            StatPoints = 0
        };
    }
}
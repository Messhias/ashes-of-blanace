using Domain.Combat;
using UnityEngine;

namespace Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Stats_Player", menuName = "Combat/Combat Stats Profile")]
    public class CombatStatsSo : ScriptableObject, ICombatStatsSo
    {
        #region Level 1 values - GDD section 8.1

        [Header("Base Stats (Level 1)")] [SerializeField]
        private float maxHp = 100f;

        [SerializeField] private float maxMp = 40f;
        [SerializeField] private int attack = 12;
        [SerializeField] private int defense = 10;
        [SerializeField] private int intelligence = 5;

        #endregion

        [Header("Regeneration")] private float _mpRegenPerSecond = 5f;

        public float MaxHp
        {
            get => maxHp;
            set => maxHp = value;
        }

        public CombatStats ToDomainStats() => new CombatStats
        {
            MaxHP = MaxHp,
            MaxMP = maxMp,
            Attack = attack,
            Defense = defense ,
            Intelligence = intelligence,
            MpRegenPerSecond = _mpRegenPerSecond
        };
    }
}
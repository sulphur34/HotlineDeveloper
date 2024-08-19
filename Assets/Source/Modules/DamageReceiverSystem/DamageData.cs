using System;
using Modules.WeaponTypes;
using UnityEngine;

namespace Modules.DamagerSystem
{
    [Serializable]
    public struct DamageData
    {
        private static readonly float _zeroDamageValue = 0f;
        private static readonly float _normalDamageValue = 1f;

        [field: SerializeField] public WeaponType WeaponType { get; private set; }

        [field: SerializeField]
        [field: Range(0, 1)]
        public float Value { get; private set; }

        [field: SerializeField] public bool IsKnockout { get; private set; }

        [field: SerializeField] public bool IsLethal { get; private set; }

        private DamageData(float value, WeaponType weaponType, bool isKnockout = false, bool isLethal = false)
        {
            Value = value;
            IsKnockout = isKnockout;
            IsLethal = isLethal;
            WeaponType = weaponType;
        }

        public static DamageData RangeDamage => new DamageData(_normalDamageValue, WeaponType.Range, false, false);

        public static DamageData ZeroDamage => new DamageData(_zeroDamageValue, WeaponType.Melee, false, false);

        public static DamageData ExecutionDamage => new DamageData(_zeroDamageValue, WeaponType.Melee, false, true);
    }
}
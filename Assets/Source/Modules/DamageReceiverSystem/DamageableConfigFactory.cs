
using UnityEngine;

namespace Modules.DamageReceiverSystem
{
    [CreateAssetMenu(fileName = "DamageableConfigFactory")]
    public class DamageableConfigFactory : ScriptableObject
    {
        [SerializeField] private DamageableConfig _normalEnemyConfig;
        [SerializeField] private DamageableConfig _strongEnemyConfig;
        [SerializeField] private DamageableConfig _bossEnemyConfig;
        [SerializeField] private DamageableConfig _immortalConfig;
        [SerializeField] private DamageableConfig _alwaysLethalConfig;
        [SerializeField] private DamageableConfig _lethalIsNormalConfig;

        public DamageableConfig GetConfig(DamageableTypes damageableType)
        {
            return damageableType switch
            {
                DamageableTypes.Normal => _normalEnemyConfig,
                DamageableTypes.Strong => _strongEnemyConfig,
                DamageableTypes.Boss => _bossEnemyConfig,
                DamageableTypes.Immortal => _immortalConfig,
                DamageableTypes.AlwaysLethal => _alwaysLethalConfig,
                DamageableTypes.LethalIsNormal => _lethalIsNormalConfig,
                _ => _normalEnemyConfig
            };
        }
    }
}
using UnityEngine;

namespace Modules.DamageSystem
{
    [CreateAssetMenu(fileName = "DamageableConfigFactory")]
    public class DamageableConfigFactory : ScriptableObject
    {
        [SerializeField] private DamageableConfig _normalEnemyConfig;
        [SerializeField] private DamageableConfig _strongEnemyConfig;
        [SerializeField] private DamageableConfig _bossEnemyConfig;
        [SerializeField] private DamageableConfig _playerConfig;

        public DamageableConfig GetConfig(DamageableTypes damageableType)
        {
            return damageableType switch
            {
                DamageableTypes.Normal => _normalEnemyConfig,
                DamageableTypes.Strong => _strongEnemyConfig,
                DamageableTypes.Boss => _bossEnemyConfig,
                DamageableTypes.Player => _playerConfig,
                _ => _normalEnemyConfig
            };
        }
    }
}
using UnityEngine;

namespace SoConfigs.UnitConfig
{
    [CreateAssetMenu(fileName = "unit", menuName = "Units/Angry Unit", order = 0)]
    public class EnemyUnitSo : ScriptableObject
    {
        [field:SerializeField] public UnitMoveConfig MoveConfig { get; private set; }
        [field:SerializeField] public UnitAttackConfig AttackConfig { get; private set; }
    }
}
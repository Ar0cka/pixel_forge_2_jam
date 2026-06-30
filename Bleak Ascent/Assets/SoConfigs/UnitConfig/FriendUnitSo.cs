using UnityEngine;

namespace SoConfigs.UnitConfig
{
    [CreateAssetMenu(fileName = "unit", menuName = "Units/Friend Unit", order = 0)]
    public class FriendUnitSo : ScriptableObject
    {
        [field:SerializeField] public UnitMoveConfig MoveConfig { get; private set; }
    }
}
using UnityEngine;

namespace Player.AttackSystem.CastSpellSystem
{
    public class PrefabFactory : MonoBehaviour
    {
        [SerializeField] private Transform _prefabParent;
        
        public GameObject CreateSpell(GameObject prefab, Vector2 startPosition)
        {
            var spell = Instantiate(prefab, _prefabParent, false);
            spell.transform.position = startPosition;
            return spell;
        }
    }
}
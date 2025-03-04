using SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants
{
    [CreateAssetMenu(menuName = "Game Data/Combatant Data")]
    public class CombatantData : ScriptableObject
    {
        public Combatant _prefab;
     
        public int _maxHp = 10;
        public float _moveSpeed = 1.0f;
        public float _turnSpeed = 1.0f;

        public WeaponData _weaponData;
    }
}

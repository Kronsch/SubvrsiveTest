using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants
{
    [CreateAssetMenu(menuName = "Game Data/Combatant Data")]
    public class CombatantData : PawnData
    {
        public int _maxHp = 10;
        public WeaponData _weaponData;
    }
}

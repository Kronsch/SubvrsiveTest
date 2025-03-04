using SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants
{
    [CreateAssetMenu(menuName = "Game Data/Combatant Data")]
    public class CombatantData : ScriptableObject
    {
        public int MaxHp = 10;
        public float MoveSpeed = 1.0f;
        public float TurnSpeed = 1.0f;

        public WeaponData WeaponData;
    }
}

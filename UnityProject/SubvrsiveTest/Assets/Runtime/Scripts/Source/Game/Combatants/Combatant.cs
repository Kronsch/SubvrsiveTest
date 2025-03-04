using System;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants
{
    public class Combatant : BasePawn
    {
        [SerializeField]
        private Weapon _weapon;
        
        public void InitializeCombatant(CombatantData combatantData)
        {
            Hp.Value = combatantData.MaxHp;
            MaxHp.Value = combatantData.MaxHp;
            MoveSpeed = combatantData.MoveSpeed;
            TurnSpeed = combatantData.TurnSpeed;
            _weapon.InitializeWeapon(combatantData.WeaponData);
        }
        
        public override void TakeDamage(int damage)
        {
            Hp.Value -= damage;

            if(Hp.Value <= 0)
            {
                HandleDeath();
            }
        }
        
        public override void SetTarget(IPawn pawn)
        {
            CurrentTarget = pawn;
        }

        private void HandleDeath()
        {
            // Perform death animation.
        }
    }
}

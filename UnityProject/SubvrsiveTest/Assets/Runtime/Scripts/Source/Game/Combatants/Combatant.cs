using System;
using SubvrsiveTest.Runtime.Scripts.Source.Base.ObservableValue;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons;
using UnityEngine;
using UnityEngine.AI;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants
{
    public class Combatant : BasePawn
    {
        [SerializeField]
        private Weapon _weapon;

        protected ObservableValue<int> Hp;
        protected ObservableValue<int> MaxHp;

        public override void InitializePawn(PawnData pawnData)
        {
            base.InitializePawn(pawnData);
            if(pawnData is CombatantData combatantData)
            {
                Hp.Value = combatantData._maxHp;
                MaxHp.Value = combatantData._maxHp;
                _weapon.InitializeWeapon(combatantData._weaponData);
            }
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
        
        public override void MoveToPosition(Vector3 worldPosition)
        {
            _navMeshAgent.SetDestination(worldPosition);
        }

        private void HandleDeath()
        {
            // Perform death animation.
        }
    }
}

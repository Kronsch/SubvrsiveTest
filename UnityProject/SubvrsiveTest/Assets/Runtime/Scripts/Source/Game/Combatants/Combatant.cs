using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using SubvrsiveTest.Runtime.Scripts.Source.Base.ObservableValue;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons;
using UnityEngine;
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

            Hp = new ObservableValue<int>();
            MaxHp = new ObservableValue<int>();

            if(pawnData is CombatantData combatantData)
            {
                Hp.Value = combatantData._maxHp;
                MaxHp.Value = combatantData._maxHp;
                _weapon.InitializeWeapon(combatantData._weaponData, this);
            }
        }
        
        public override void ApplyDamage(int damage)
        {
            Hp.Value -= damage;
            if(Hp.Value <= 0)
            {
                this.Log($"Pawns hp has reached zero. Handling death.");
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
            Destroy(gameObject);
            // Perform death animation.
        }
    }
}

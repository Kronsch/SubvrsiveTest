using SubvrsiveTest.Runtime.Scripts.Source.Base.ObservableValue;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public abstract class BasePawn : MonoBehaviour, IPawn
    {
        protected ObservableValue<int> Hp;
        protected ObservableValue<int> MaxHp;

        protected float MoveSpeed;
        protected float TurnSpeed;

        protected IPawn CurrentTarget;
        
        public abstract void TakeDamage(int damage);
        public abstract void SetTarget(IPawn pawn);
    }
}

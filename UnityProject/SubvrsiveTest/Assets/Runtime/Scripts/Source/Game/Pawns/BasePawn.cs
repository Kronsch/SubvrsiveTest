using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using UnityEngine;
using UnityEngine.AI;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public abstract class BasePawn : MonoBehaviour, IPawn, ILoggable
    {
        [SerializeField] protected NavMeshAgent _navMeshAgent;

        private float _moveSpeed;
        private float _turnSpeed;

        protected IPawn CurrentTarget;

        public bool DebugLogsEnabled { get; set; } = true;
        
        public virtual void InitializePawn(PawnData pawnData)
        {
            _moveSpeed = pawnData._moveSpeed;
            _turnSpeed = pawnData._turnSpeed;
            InitializeNavMeshAgent();
        }

        private void InitializeNavMeshAgent()
        {
            _navMeshAgent.speed = _moveSpeed;
            _navMeshAgent.angularSpeed = _turnSpeed;
        }

        public abstract void ApplyDamage(int damage);
        public abstract void SetTarget(IPawn pawn);
        public abstract void MoveToPosition(Vector3 worldPosition);
        
    }
}

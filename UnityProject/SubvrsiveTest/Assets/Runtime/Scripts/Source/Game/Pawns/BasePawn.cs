using System;
using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using UnityEngine;
using UnityEngine.AI;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public abstract class BasePawn : MonoBehaviour, IPawn, ILoggable
    {
        [SerializeField] protected NavMeshAgent _navMeshAgent;

        private Transform _transform;
        
        private float _moveSpeed;
        private float _turnSpeed;

        private Quaternion _currentRotation;
        private Quaternion _targetRotation;

        public IPawn CurrentTarget { get; set; }
        public Guid PawnID { get; set; }
        public Vector3 WorldPosition => _transform.position;
        public event Action TargetPawnDestroyed;
        public event Action<Guid> PawnDestroyed;

        public bool DebugLogsEnabled { get; set; } = true;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            UpdateRotation();
        }

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
        
        public virtual void MoveToPosition(Vector3 worldPosition)
        {
            _navMeshAgent.SetDestination(worldPosition);
        }
        
        public virtual void Move(Vector3 offset)
        {
            _navMeshAgent.SetDestination(_transform.position + offset);
        }
        
        public virtual void SetTarget(IPawn pawn)
        {
            if(CurrentTarget != default)
            {
                CurrentTarget.PawnDestroyed -= OnTargetPawnDestroyed;
            }
            
            CurrentTarget = pawn;

            if(CurrentTarget != default)
            {
                CurrentTarget.PawnDestroyed += OnTargetPawnDestroyed;
            }
        }

        private void UpdateRotation()
        {
            if(CurrentTarget == default)
            {
                return;
            }
            
            SetLookAtTargetRotation(CurrentTarget.WorldPosition);
            _currentRotation = _transform.rotation;
            if(Quaternion.Angle(_currentRotation, _targetRotation) > Single.Epsilon)
            {
                _currentRotation = Quaternion.RotateTowards(_currentRotation, _targetRotation, _turnSpeed * Time.deltaTime);
                _transform.rotation = _currentRotation;
            }
        }
        
        private void SetLookAtTargetRotation(Vector3 targetWorldPosition)
        {
            var targetDirection = (targetWorldPosition - WorldPosition).normalized;
            _targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        }
        
        private void OnTargetPawnDestroyed(Guid pawnID)
        {
            TargetPawnDestroyed?.Invoke();
            CurrentTarget = default;
        }

        protected virtual void OnDestroy()
        {
            PawnDestroyed?.Invoke(PawnID);
        }
    }
}

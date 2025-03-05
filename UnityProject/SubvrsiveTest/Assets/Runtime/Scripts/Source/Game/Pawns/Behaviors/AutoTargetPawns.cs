using System;
using System.Collections.Generic;
using System.Linq;
using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants;
using UnityEngine;
using Random = UnityEngine.Random;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns.Behaviors
{
    public class AutoTargetPawns : MonoBehaviour, ILoggable
    {
        [SerializeField] private BasePawn _selfPawn;
        [SerializeField] private bool _autoSearchEnabled;
        [SerializeField] private float _searchMoveDistance = 5.0f;
        [SerializeField] private float _searchCooldownDurationSecs = 3.0f;

        // Key: Pawn ID -> Value: Pawn Instance)
        private IDictionary<Guid, IPawn> _pawnsInRange = new Dictionary<Guid, IPawn>();

        private float _searchCooldownTimeLeft;
        
        public bool DebugLogsEnabled { get; set; } = true;

        private void Start()
        {
            _selfPawn.TargetPawnDestroyed += OnTargetPawnDestroyed;
            PerformNextTargetSearch();
        }

        private void Update()
        {
            if(_selfPawn.CurrentTarget == default)
            {
                if(_searchCooldownTimeLeft <= 0.0f)
                {
                    PerformNextTargetSearch();
                }
                else
                {
                    _searchCooldownTimeLeft -= Time.deltaTime;
                }
            }
        }

        private void SetTarget(IPawn targetPawn)
        {
            _selfPawn.SetTarget(targetPawn);
        }

        private void PerformNextTargetSearch()
        {
            if(_pawnsInRange.Count > 0)
            {
                var randomPawnInRange = _pawnsInRange.Values.ToArray()[Random.Range(0, _pawnsInRange.Count)];
                SetTarget(randomPawnInRange);
                return;
            }
            
            if(_autoSearchEnabled)
            {
                MoveInRandomDirection();
                _searchCooldownTimeLeft = _searchCooldownDurationSecs;
            }
        }

        private void MoveInRandomDirection()
        {
            var randUnitCircle = Random.insideUnitCircle;
            var offset = randUnitCircle.normalized * _searchMoveDistance;
            _selfPawn.Move(new Vector3(offset.x, 0f, offset.y));
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<PawnObjectReference>(out var pawnRef))
            {
                if(!PawnIsValidTarget(pawnRef.Reference))
                {
                    return;
                }
                
                TryRegisterPawnInRange(pawnRef.Reference);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.TryGetComponent<PawnObjectReference>(out var pawnRef))
            {
                TryForgetPawnInRange(pawnRef.Reference.PawnID);
            }
        }

        private void TryRegisterPawnInRange(IPawn pawn)
        {
            if(_pawnsInRange.ContainsKey(pawn.PawnID))
            {
                return;
            }
            
            _pawnsInRange.Add(pawn.PawnID, pawn);
            pawn.PawnDestroyed += OnInRangePawnDestroyed;
        }

        private void TryForgetPawnInRange(Guid pawnID)
        {
            if(!_pawnsInRange.ContainsKey(pawnID))
            {
                return;
            }

            this.Log($"TryForgetPawnInRange: Self Pawn ID {_selfPawn.PawnID.GetHashCode()} -- Forgetting pawn {pawnID.GetHashCode()}");
            var pawn = _pawnsInRange[pawnID];
            pawn.PawnDestroyed -= OnInRangePawnDestroyed;
            _pawnsInRange.Remove(pawnID);
        }

        private bool PawnIsValidTarget(IPawn pawn)
        {
            // Ignore pawns that are dead.
            if(pawn is Combatant combatant && combatant.Hp.Value <= 0)
            {
                return false;
            }
            
            // Ignore the pawn that this behavior belongs to.
            return pawn.PawnID != _selfPawn.PawnID;
        }
        
        private void OnTargetPawnDestroyed()
        {
            if(_selfPawn.CurrentTarget != default &&
               _pawnsInRange.ContainsKey(_selfPawn.CurrentTarget.PawnID))
            {
                TryForgetPawnInRange(_selfPawn.CurrentTarget.PawnID);
                return;
            }
            
            PerformNextTargetSearch();
        }

        private void OnInRangePawnDestroyed(Guid pawnID)
        {
            TryForgetPawnInRange(pawnID);
        }

        private void OnDestroy()
        {
            _selfPawn.TargetPawnDestroyed -= OnTargetPawnDestroyed;
            foreach(var entry in _pawnsInRange)
            {
                entry.Value.PawnDestroyed -= OnInRangePawnDestroyed;
            }
        }
    }
}

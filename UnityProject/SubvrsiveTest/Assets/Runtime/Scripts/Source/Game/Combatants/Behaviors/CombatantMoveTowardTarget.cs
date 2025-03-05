using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants.Behaviors
{
    public class CombatantMoveTowardTarget : MonoBehaviour
    {
        [SerializeField] private Combatant _selfCombatant;
        [SerializeField] private float _moveTowardTargetDistance = 5.0f;
        [SerializeField] private float _moveCooldownDurationSecs = 3.0f;
        
        private float _moveCooldownTimeLeft;
        
        private void Update()
        {
            if(_selfCombatant.CurrentTarget != default && !_selfCombatant.TargetIsInRange())
            {
                if(_moveCooldownTimeLeft <= 0.0f)
                {
                    MoveTowardTarget();
                }
                else
                {
                    _moveCooldownTimeLeft -= Time.deltaTime;
                }
            }
        }
        
        private void MoveTowardTarget()
        {
            var targetDirection = (_selfCombatant.CurrentTarget.WorldPosition - _selfCombatant.WorldPosition).normalized;
            var offset = targetDirection * _moveTowardTargetDistance;
            _selfCombatant.Move(offset);
            _moveCooldownTimeLeft = _moveCooldownDurationSecs;
        }
    }
}

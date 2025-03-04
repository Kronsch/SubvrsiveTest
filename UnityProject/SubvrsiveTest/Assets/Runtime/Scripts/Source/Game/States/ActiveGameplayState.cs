using SubvrsiveTest.Runtime.Scripts.Source.Base.FSM;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.States
{
    public class ActiveGameplayState : BaseState<GameplayStates>
    {
        [SerializeField] private CombatantSpawner _combatantSpawner;
        [SerializeField] private PawnManager _pawnManager;
        [SerializeField] private int _combatantCount = 10;
        
        public override GameplayStates ID { get; } = GameplayStates.Active;
        
        public override void Enter()
        {
            _combatantSpawner.SpawnCombatants(_combatantCount);
            _pawnManager.PawnDestroyed += OnPawnDestroyed;
        }

        public override void Update()
        {
            
        }
        
        public override void Exit()
        {
            _pawnManager.PawnDestroyed -= OnPawnDestroyed;
        }
        
        private void OnPawnDestroyed()
        {
            CheckForCompleteCondition();
        }

        private void CheckForCompleteCondition()
        {
            if(_pawnManager.PawnCount == 1)
            {
                StateMachine.SetState(GameplayStates.Complete);
            }
        }
    }
}

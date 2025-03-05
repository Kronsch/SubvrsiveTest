using SubvrsiveTest.Runtime.Scripts.Source.Base.FSM;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using SubvrsiveTest.Runtime.Scripts.Source.UI.Screens;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.States
{
    public class CompleteGameplayState : BaseState<GameplayStates>
    {
        [SerializeField] private CompleteScreen _completeScreen;

        private IPawn _winningPawn;
        
        public override GameplayStates ID => GameplayStates.Complete;

        public override void Enter()
        {
            _completeScreen.Visible = true;
            _completeScreen.RestartButtonPressed += OnRestartButtonPressed;
            _completeScreen.SetWinningCombatantGuid(_winningPawn.PawnID);
        }

        public override void Update()
        {
            
        }
        
        public override void Exit()
        {
            _completeScreen.Visible = false;
            _completeScreen.RestartButtonPressed -= OnRestartButtonPressed;
        }

        public void SetWinningPawn(IPawn winningPawn)
        {
            _winningPawn = winningPawn;
        }

        private void OnRestartButtonPressed()
        {
            StateMachine.SetState(GameplayStates.Start);
        }
    }
}

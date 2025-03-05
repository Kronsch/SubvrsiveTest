using SubvrsiveTest.Runtime.Scripts.Source.Base.FSM;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using SubvrsiveTest.Runtime.Scripts.Source.UI.Screens;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.States
{
    public class StartGameplayState : BaseState<GameplayStates>
    {
        [SerializeField] private StartGameScreen _startGameScreen;
        [SerializeField] private ActiveGameplayState _activeGameplayState;
        [SerializeField] private PawnManager _pawnManager;
        
        public override GameplayStates ID => GameplayStates.Start;

        public override void Enter()
        {
            _pawnManager.DestroyAllPawns();
            _startGameScreen.Visible = true;
            _startGameScreen.StartGameButtonPressed += OnStartGameButtonPressed;
        }

        public override void Update()
        {
            
        }
        
        public override void Exit()
        {
            _startGameScreen.Visible = false;
            _startGameScreen.StartGameButtonPressed -= OnStartGameButtonPressed;
        }
        
        private void OnStartGameButtonPressed(int combatantCount)
        {
            _activeGameplayState.SetCombatantCount(combatantCount);
            StateMachine.SetState(GameplayStates.Active);
        }
    }
}

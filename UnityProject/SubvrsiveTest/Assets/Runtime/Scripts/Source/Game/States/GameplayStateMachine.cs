using System.Collections.Generic;
using SubvrsiveTest.Runtime.Scripts.Source.Base.FSM;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.States
{
    public class GameplayStateMachine : BaseStateMachine<GameplayStates>
    {
        [SerializeField] private StartGameplayState _startState;
        [SerializeField] private ActiveGameplayState _activeState;
        [SerializeField] private CompleteGameplayState _completeState;
        
        protected override GameplayStates DefaultStateID { get; } = GameplayStates.Start;
        protected override void InitializeStates()
        {
            States = new List<IState<GameplayStates>>();
            States.Add(_startState);
            States.Add(_activeState);
            States.Add(_completeState);

            foreach(var state in States)
            {
                state.Initialize(this, DebugLogsEnabled);
            }
        }
    }
}

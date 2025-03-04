using System.Collections.Generic;
using SubvrsiveTest.Runtime.Scripts.Source.Base.FSM;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.States
{
    public class GameplayStateMachine : BaseStateMachine<GameplayStates>
    {
        public GameplayStateMachine(bool debugLogsEnabled) : base(debugLogsEnabled) { }

        protected override GameplayStates DefaultStateID { get; } = GameplayStates.Active;
        protected override void InitializeStates()
        {
            States = new List<IState<GameplayStates>>();
            States.Add(new ActiveGameplayState());
            States.Add(new CompleteGameplayState());
        }
    }
}

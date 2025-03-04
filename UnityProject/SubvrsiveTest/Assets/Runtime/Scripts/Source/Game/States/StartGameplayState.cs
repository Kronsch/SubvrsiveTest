using SubvrsiveTest.Runtime.Scripts.Source.Base.FSM;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.States
{
    public class StartGameplayState : BaseState<GameplayStates>
    {
        public override GameplayStates ID { get; } = GameplayStates.Start;
        
        public override void Enter()
        {
            // TODO: Add UI start screen with start button. For now just automatically transition into the active state.
            StateMachine.SetState(GameplayStates.Active);
        }
        
        public override void Update()
        {
            
        }
        
        public override void Exit()
        {
            
        }
    }
}

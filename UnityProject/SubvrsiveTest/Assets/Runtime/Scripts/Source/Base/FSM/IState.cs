using System;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.FSM
{
    public interface IState<T> where T: Enum
    {
        BaseStateMachine<T> StateMachine { get; set; }
        T ID { get; }
        void Initialize(BaseStateMachine<T> stateMachine, bool debugLogsEnabled);
        void Enter();
        void Update();
        void Exit();
    }
}

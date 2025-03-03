using System;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.FSM
{
    public interface IState<T> where T: Enum
    {
        T ID { get; }
        void Enter();
        void Update();
        void Exit();
    }
}

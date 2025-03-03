using System;
using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.FSM
{
    public abstract class BaseState<T> : IState<T>, ILoggable where T: Enum
    {
        public abstract T ID { get; }
        public bool DebugLogsEnabled { get; set; }

        public BaseState(bool debugLogsEnabled = false)
        {
            DebugLogsEnabled = debugLogsEnabled;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}

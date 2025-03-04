using System;
using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.FSM
{
    public abstract class BaseState<T> : MonoBehaviour, IState<T>, ILoggable where T: Enum
    {
        public BaseStateMachine<T> StateMachine { get; set; }
        public abstract T ID { get; }
        public bool DebugLogsEnabled { get; set; }

        public void Initialize(BaseStateMachine<T> stateMachine, bool debugLogsEnabled = false)
        {
            StateMachine = stateMachine;
            DebugLogsEnabled = debugLogsEnabled;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using SubvrsiveTest.Runtime.Scripts.Source.Base.UniTaskExtensions;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.FSM
{
    public abstract class BaseStateMachine<T> : MonoBehaviour, IStateMachine, ILoggable, IUniTaskable where T: Enum
    {
        [SerializeField] private bool _debugLogsEnabled;
        
        protected IList<IState<T>> States;
        protected IState<T> ActiveState;
        
        protected abstract T DefaultStateID { get; }

        public bool DebugLogsEnabled { get; set; }

        private void Start()
        {
            DebugLogsEnabled = _debugLogsEnabled;
            Initialize();
        }

        protected abstract void InitializeStates();
        protected virtual void Initialize()
        {
            InitializeStates();
            SetState(DefaultStateID);
        }
        
        public async void SetState(T stateID)
        {
            var state = States.FirstOrDefault(s => s.ID.Equals(stateID));
            if(state == null)
            {
                this.LogError($"Error: State does not exist [{stateID}]");
            }
            
            this.Log($"Moving to next state: {stateID}");
            await TransitionToNextState(state);
        }
        
        protected async UniTask TransitionToNextState(IState<T> nextState)
        {
            ActiveState?.Exit();
        
            if(ActiveState != null)
            {
                ActiveState = null;
                await this.CreateFrameDelay();
            }

            ActiveState = nextState;
            ActiveState.Enter();
        }

        public virtual void UpdateTick()
        {
            if(ActiveState != null)
            {
                UpdateActiveState();
            }
        }

        protected void UpdateActiveState()
        {
            ActiveState?.Update();
        }
    }
}

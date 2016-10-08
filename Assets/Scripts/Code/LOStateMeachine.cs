using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM
{
    public class LOStateMeachine : LOState, IStateMeachine
    {
        private IState _currentState;
        private IState _defaultState;
        private List<IState> _states;

        private bool _isTransiton = false;

        private ITransition _t;

        public LOStateMeachine(string name, IState state)
            : base(name)
        {
            _states = new List<IState>();
            DefaultState = state;
        }

        public IState CurrentState
        {
            get { return _currentState; }
        }

        public IState DefaultState
        {
            get
            {
                return _defaultState;
            }
            set
            {
                AddState(value);
                _defaultState = value;
            }
        }

        public void AddState(IState state)
        {
            if (state != null && !_states.Contains(state))
            {
                _states.Add(state);
                state.Parent = this;
                if (_defaultState == null)
                {
                    _defaultState = state;
                }
            }
        }

        public void RemoveState(IState state)
        {
            if (_currentState == state)
            {
                return;
            }
            if (state != null && _states.Contains(state))
            {
                _states.Remove(state);
                state.Parent = null;
                if (_defaultState == state)
                {
                    _defaultState = (_states.Count >= 1 ? _states[0] : null);
                }
            }
        }

        public IState GetStateWithTag(string tag)
        {
            return null;
        }

        public override void UpdateCallback(float deltaTime)
        {
            if (_isTransiton)
            {
                if (_t.TransitionCallback())
                {
                    DoTransiton(_t);
                    _isTransiton = false;
                }
                return;
            }
            if (_currentState == null)
            {
                _currentState = _defaultState;
            }
            base.UpdateCallback(deltaTime);
            List<ITransition> ts = _currentState.Transitions;
            int count = ts.Count;
            for (int i = 0; i < count; i++)
            {
                ITransition t = ts[i];
                if (t.ShouldBegin())
                {
                    _isTransiton = true;
                    _t = t;
                    return;
                }
            }
            _currentState.UpdateCallback(deltaTime);
        }

        public override void LateUpdateCallback(float deltaTime)
        {
            base.LateUpdateCallback(deltaTime);
            _currentState.LateUpdateCallback(deltaTime);
        }

        /// <summary>
        /// 开始过度
        /// </summary>
        private void DoTransiton(ITransition t)
        {
            Debug.LogError("开始过度");
            _currentState.ExitCallback(t.To);
            _currentState = t.To;
            _currentState.EnterCallback(t.From);
        }

    }
}

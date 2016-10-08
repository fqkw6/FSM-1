using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM
{
    public delegate void LOStateDelegate();
    public delegate void LOStateDelegeteState(IState state);
    public delegate void LOStateDelegeteFloat(float f);


    public class LOState : IState
    {
        public event LOStateDelegeteState OnEnter;
        public event LOStateDelegeteState OnExit;

        public event LOStateDelegeteFloat OnUpdate;
        public event LOStateDelegeteFloat OnLateUpdate;
        public event LOStateDelegate OnFixedUpdate;
        public string Name
        {
            get { return _name; }
        }

        public string Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public float Timer
        {
            get { return _timer; }
        }
        public List<ITransition> Transitions
        {
            get { return _transitions; }
        }
        public IStateMeachine Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        public LOState(string name)
        {
            _name = name;
            _transitions = new List<ITransition>();
        }

        public void AddTranstion(ITransition t)
        {
            if (t != null && !_transitions.Contains(t))
            {
                _transitions.Add(t);
            }
        }

        public virtual void EnterCallback(IState prev)
        {
            _timer = 0;
            if (OnEnter != null)
            {
                OnEnter(prev);
            }
        }

        public virtual void ExitCallback(IState next)
        {
            if (OnExit != null)
            {
                OnExit(next);
            }
            _timer = 0;
        }

        public virtual void UpdateCallback(float deltaTime)
        {
            _timer += deltaTime;
            if (OnUpdate != null)
            {
                OnUpdate(deltaTime);
            }
        }

        public virtual void LateUpdateCallback(float deltaTime)
        {
            if (OnLateUpdate != null)
            {
                OnLateUpdate(deltaTime);
            }
        }

        public virtual void FixedUpdateCallback()
        {
            if (OnFixedUpdate != null)
            {
                OnFixedUpdate();
            }

        }

        private string _name;
        private string _tag;
        private IStateMeachine _parent;
        private float _timer;
        private List<ITransition> _transitions;
    }
}

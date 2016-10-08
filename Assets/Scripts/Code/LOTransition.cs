using UnityEngine;
using System.Collections;
namespace FSM
{
    public delegate bool LoTransitonDelegate();
    public class LOTransition : ITransition
    {

        public event LoTransitonDelegate OnTransition;
        public event LoTransitonDelegate OnCheck;

        private IState _from;
        private IState _to;
        private string _name;

        public bool TransitionCallback()
        {
            if (OnTransition != null)
            {
                return OnTransition();
            }
            return true;
        }


        public IState From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        public IState To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
            }
        }


        public string Name
        {
            get { return _name; }
        }

        public LOTransition(string name, IState fromState, IState toState)
        {
            _name = name;
            _from = fromState;
            _to = toState;
        }


        public bool ShouldBegin()
        {
            if (OnCheck != null)
            {
                return OnCheck();
            }
            return false;
        }
    }
}
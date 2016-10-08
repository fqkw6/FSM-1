using UnityEngine;
using System.Collections;
namespace FSM
{
    public interface ITransition
    {
        /// <summary>
        /// 从哪个状态开始过渡
        /// </summary>
        IState From { get; set; }


        /// <summary>
        /// 过渡到哪个状态
        /// </summary>
        IState To { get; set; }

        string Name { get; }

        bool TransitionCallback();

        bool ShouldBegin();

    }
}
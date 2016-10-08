using UnityEngine;
using System.Collections;

namespace FSM
{
    public interface IStateMeachine
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        IState CurrentState { get; }

        /// <summary>
        /// 默认状态
        /// </summary>
        IState DefaultState { set; get; }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state"></param>
        void AddState(IState state);


        /// <summary>
        /// 删除状态
        /// </summary>
        /// <param name="state"></param>
        void RemoveState(IState state);

        /// <summary>
        /// 通过Tag 值查找状态
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>查找到的状态</returns>
        IState GetStateWithTag(string tag);

    }
}
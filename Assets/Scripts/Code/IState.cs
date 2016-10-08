using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 状态名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 状态标签
        /// </summary>
        string Tag { set; get; }

        /// <summary>
        /// 当前状态的状态机
        /// </summary>
        IStateMeachine Parent { set; get; }

        /// <summary>
        /// 从进入状态开始计算的时长
        /// </summary>
        float Timer { get; }

        /// <summary>
        /// 
        /// </summary>
        List<ITransition> Transitions { get; }


        /// <summary>
        /// 进入状态时的回调
        /// </summary>
        /// <param name="prev">上一个状态</param>
        void EnterCallback(IState prev);

        /// <summary>
        /// 退出状态时的回调
        /// </summary>
        /// <param name="next">下一个状态</param>
        void ExitCallback(IState next);

        /// <summary>
        /// Update的回调
        /// </summary>
        /// <param name="deltaTime"></param>
        void UpdateCallback(float deltaTime);

        /// <summary>
        /// LateUpdate的回调
        /// </summary>
        /// <param name="deltaTime"></param>
        void LateUpdateCallback(float deltaTime);


        /// <summary>
        /// FixedUpdate的回调
        /// </summary>
        void FixedUpdateCallback();

        void AddTranstion(ITransition t);
    }
}
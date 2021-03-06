using GoblinFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinFramework.Core.FSMachine
{
    /// <summary>
    /// Finite-State-Machine-Lock-Comp，状态机，锁步状态机组件
    /// </summary>
    /// <typeparam name="E">引擎组件类型</typeparam>
    /// <typeparam name="MT">状态机类型</typeparam>
    /// <typeparam name="ST">状态类型</typeparam>
    public abstract class FSMLockstepComp<E, MT, ST> : FSMComp<E, MT, ST> where E : GameEngineComp<E>, new() where MT : FSMLockstepComp<E, MT, ST>, new() where ST : FSMLockstepState<E, MT, ST>, new()
    {
        /// <summary>
        /// 切换至指定状态，且指定状态在通行列表中
        /// </summary>
        /// <typeparam name="T">FSMLockstepState 状态类型</typeparam>
        public new void EnterState<T>() where T : ST
        {
            var targetState = GetState<T>();

            if (null == State)
            {
                EnterState(targetState);
                return;
            }

            if (false == State.PassStates.Contains(typeof(T))) throw new Exception($"can't turn to {typeof(T)}. because cur state is {State}");

            EnterState(targetState);
        }
    }
}

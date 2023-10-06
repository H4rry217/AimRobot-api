using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api {

    /// <summary>
    /// 反作弊的策略。如ARL会时刻检测玩家并传递名字、PlayerId至所有反作弊策略类
    /// </summary>
    public interface IAntiCheat {

        /// <summary>
        /// <para>检测回调，ARL会不断传入待检测的Name和Id至所有注册在IGameContext的IAntiCheat实现类</para>
        /// <para>各个IAntiCheat模块的检测过程可能比较耗时（根据不同的方式），所以你需要在检测完毕后调用CheckResult回调</para>
        /// <para>如果调用回调时result参数为true，ARL会屏蔽该玩家，反之则略过</para>
        /// </summary>
        /// <param name="result">检测结果，如果true，则会屏蔽该玩家并公屏发送对应的中英文屏蔽原因</param>
        /// <param name="chsReason">屏蔽原因（中文）</param>
        /// <param name="engReason">屏蔽原因（英文）</param>
        public delegate void CheckResult(bool result, string chsReason, string engReason);

        /// <summary>
        /// ARL将会调用此方法，CheckResult中的result将决定是否屏蔽传入的玩家
        /// </summary>
        /// <param name="name"></param>
        /// <param name="checkResult"></param>
        public void IsAbnormalPlayer(string name, CheckResult checkResult);

        /// <summary>
        /// ARL将会调用此方法，CheckResult中的result将决定是否屏蔽传入的玩家
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="checkResult"></param>
        public void IsAbnormalPlayer(long playerId, CheckResult checkResult);

    }
}

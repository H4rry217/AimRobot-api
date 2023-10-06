using AimRobot.Api.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api {
    public interface IGameContext {

        /// <summary>
        /// 查询数据的回调，当查询数据完毕时会执行该回调
        /// </summary>
        /// <param name="playerStat"></param>
        delegate void StatCallBack(PlayerStatInfo playerStat);

        /// <summary>
        /// 当参数中指定名称的玩家在对局中时，返回对应玩家的PlayerId，否则返回0
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        long GetPlayerId(string name);

        /// <summary>
        /// 获取运行着当前AR程序的玩家的名字
        /// </summary>
        /// <returns></returns>
        string GetCurrentPlayerName();

        /// <summary>
        /// 获取当前正在进行的游戏对局的GameId
        /// </summary>
        /// <returns></returns>
        long GetCurrentGameId();

        /// <summary>
        /// 查询玩家数据（名称,等级，击杀，KPM等数据），当查询完毕时会执行StatCallBack回调
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="callBack"></param>
        void GetPlayerStatInfo(long playerId, StatCallBack callBack);

        /// <summary>
        /// 查询玩家数据（名称，等级，击杀，KPM等数据），当查询完毕时会执行StatCallBack回调
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="callBack"></param>
        void GetPlayerStatInfo(string playerName, StatCallBack callBack);

        /// <summary>
        /// <para>添加反作弊策略，可以实现IAntiCheat并调用本方法传递一个反作弊策略</para>
        /// </summary>
        /// <param name="antiCheat"></param>
        void AddAntiCheat(IAntiCheat antiCheat);

        /// <summary>
        /// 检测该玩家的数据情况，如是否作弊
        /// </summary>
        /// <param name="playerId"></param>
        void PlayerCheck(long playerId);

        /// <summary>
        /// 检测该玩家的数据情况，如是否作弊
        /// </summary>
        /// <param name="playerName"></param>
        void PlayerCheck(string  playerName);

    }
}

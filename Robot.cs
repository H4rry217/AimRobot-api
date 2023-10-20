using AimRobot.Api.plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api {
    public abstract class Robot {

        private static Robot instance;

        public abstract void BanPlayer(long playerId);

        public abstract void BanPlayer(string name);

        public abstract void BanPlayer(string name, string reason);

        public abstract void KickPlayer(long playerId);

        public abstract void KickPlayer(string name);

        public abstract void KickPlayer(string name, string reason);

        public abstract void UnBanPlayer(long playerId);

        public abstract void UnBanPlayer(string name);

        public abstract void SendChat(string message);

        public abstract void JoinGame(long gameId);

        public abstract bool IsEnable();

        /// <summary>
        /// 获取机器人运行中的数据上下文等信息
        /// </summary>
        /// <returns></returns>
        public abstract IGameContext GetGameContext();

        /// <summary>
        /// 获取机器人的日志组件
        /// </summary>
        /// <returns></returns>
        public abstract IRobotLogger GetLogger();

        /// <summary>
        /// 获取运行的目录
        /// </summary>
        /// <returns></returns>
        public abstract string GetDirectory();

        public abstract PluginManager GetPluginManager();

        /// <summary>
        /// <para>ARL初始化时会构造对应的Robot对象并注入至instance中</para>
        /// <para>插件被加载时，其生命周期内已经可以使用该方法获取Robot对象</para>
        /// </summary>
        /// <returns>Robot</returns>
        public static Robot GetInstance() {
            return instance;
        }

        public static void Init(Robot robot) {
            if (instance == null) {
                instance = robot;
            }
        }

    }
}

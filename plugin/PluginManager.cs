using AimRobot.Api.command;
using AimRobot.Api.events;
using AimRobot.Api.events.ev;
using System.Reflection;
using System.Text;
using static AimRobot.Api.command.ICommandListener;

namespace AimRobot.Api.plugin {
    public abstract class PluginManager {

        protected Robot robot;

        public PluginManager(Robot robot) { 
            this.robot = robot;
        }

        public abstract void LoadPlugin(PluginBase plugin);

        public abstract bool EnablePlugin(PluginBase plugin);

        public abstract bool DisablePlugin(PluginBase plugin);

        /// <summary>
        /// <para>注册IEventListener和其实现类内的所有EventHandler，若ARL收到对应EventHandler感兴趣的事件，则会执行EventHandler标注的方法</para>
        /// </summary>
        /// <param name="plugin"></param>
        /// <param name="eventListener"></param>
        public abstract void RegisterListener(PluginBase plugin, IEventListener eventListener);

        /// <summary>
        /// 注销IEventListener。
        /// </summary>
        /// <param name="eventListener"></param>
        public abstract void UnregisterListener(IEventListener eventListener);

        /// <summary>
        /// 注册ICommandListener。注册后若收到对应的指令，将传递给该ICommandListener
        /// </summary>
        /// <param name="commandListener"></param>
        public abstract void RegisterCommandListener(PluginBase plugin, ICommandListener commandListener);

        /// <summary>
        /// 注销ICommandListener。注销后若收到对应的指令，将不会传递给该ICommandListener
        /// </summary>
        /// <param name="commandListener"></param>
        public abstract void UnregisterCommandListener(ICommandListener commandListener);

        /// <summary>
        /// 根据传入的RobotEvent事件类型，传递给每一个“订阅”了该事件类型的IEventListener的EventHandler
        /// </summary>
        /// <param name="robotEvent">继承至RobotEvent的所有事件</param>
        public abstract void CallEvent(RobotEvent robotEvent);

        public abstract void CheckCommand(string sender, string content);

        public abstract void CallCommmand(string keyword, CommandData commandData);

        public abstract PluginBase GetPlugin(string pluginName);

        public abstract ISet<PluginBase> GetPlugins();

    }
}

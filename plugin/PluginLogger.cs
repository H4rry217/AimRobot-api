using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.plugin {

    /// <summary>
    /// 插件日志，每个IPlugin实现对象都会有一个对应的专属日志组件，用于区分主日志组件和其它插件的日志组件
    /// </summary>
    public class PluginLogger : IRobotLogger {

        private IRobotLogger RobotLogger;
        private IPlugin Plugin;

        public PluginLogger(IRobotLogger logger, IPlugin plugin) {
            this.Plugin = plugin;
            this.RobotLogger = logger;
        }

        public void Debug(string s) {
            RobotLogger.Debug($"[{this.Plugin.GetPluginName()}] {s}");
        }

        public void Error(string s) {
            RobotLogger.Error($"[{this.Plugin.GetPluginName()}] {s}");
        }

        public void Fatal(string s) {
            RobotLogger.Fatal($"[{this.Plugin.GetPluginName()}] {s}");
        }

        public void Info(string s) {
            RobotLogger.Info($"[{this.Plugin.GetPluginName()}] {s}");
        }

        public void Warn(string s) {
            RobotLogger.Warn($"[{this.Plugin.GetPluginName()}] {s}");
        }

    }
}

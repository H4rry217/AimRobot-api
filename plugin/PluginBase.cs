using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.plugin{

    /// <summary>
    /// 插件的抽象类，若想编写插件需要继承该类
    /// </summary>
    public abstract class PluginBase : IPlugin {

        private IPluginLoader loader;
        private bool enable = false;
        private bool initialize = false;

        private PluginLogger logger;
        private Robot robot;

        public IPluginLoader GetPluginLoader() {
            return this.loader;
        }

        public PluginLogger GetLogger() {
            return this.logger;
        }

        public bool IsEnable() {
            return this.enable;
        }

        public void SetEnable() {
            this.SetEnable(true);
        }

        public void SetEnable(bool isEnable) {
            if (this.enable != isEnable) {
                this.enable = isEnable;
            }
        }

        public void Init(Robot robot, IPluginLoader pluginLoader) {
            if (!this.initialize) {
                this.loader = pluginLoader;
                this.logger = new PluginLogger(robot.GetLogger(), this);

                this.initialize = true;
            }
        }

        public abstract void OnDisable();

        public abstract void OnEnable();

        public abstract void OnLoad();

        public abstract string GetAuthor();

        public abstract Version GetVersion();

        public abstract string GetPluginName();

        public abstract string GetDescription();
    }
}

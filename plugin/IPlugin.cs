using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.plugin {

    /// <summary>
    /// 如果需要编写插件，请继承PluginBase抽象类
    /// </summary>
    public interface IPlugin {

        /// <summary>
        /// 插件的作者，ARL将会显示该信息
        /// </summary>
        /// <returns></returns>
        string GetAuthor();

        /// <summary>
        /// 插件的版本，ARL将会显示该信息
        /// </summary>
        /// <returns></returns>
        Version GetVersion();

        /// <summary>
        /// 插件的名字，ARL将会显示该信息，也是和其它插件区分的关键标志。建议仅用英文字母组成以避免不必要的问题
        /// </summary>
        /// <returns></returns>
        string GetPluginName();

        /// <summary>
        /// 插件的描述，ARL将会显示该信息
        /// </summary>
        /// <returns></returns>
        string GetDescription();

        /// <summary>
        /// 获取插件的加载器
        /// </summary>
        /// <returns></returns>
        IPluginLoader GetPluginLoader();

        /// <summary>
        /// 插件生命周期的第一个周期，当插件被加载但未启用时会调用该方法，在整个ARL运行期间仅会调用1次
        /// </summary>
        void OnLoad();

        /// <summary>
        /// 插件生命周期的第二个周期，当插件被启用时会调用该方法，在整个ARL运行期间可能会调用多次（重复启用或关闭插件）
        /// </summary>
        void OnEnable();

        /// <summary>
        /// 插件生命周期的第二个周期，当插件被禁用时会调用该方法，在整个ARL运行期间可能会调用多次（重复启用或关闭插件）
        /// </summary>
        void OnDisable();

        bool IsEnable();

        /// <summary>
        /// 获取插件专属的日志组件
        /// </summary>
        /// <returns></returns>
        PluginLogger GetLogger();

    }
}

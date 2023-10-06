using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.plugin {

    /// <summary>
    /// 插件的加载类，实现类需要负责通过传入的文件路径，将对应的文件转化为IPlugin对象
    /// </summary>
    public interface IPluginLoader {

        public IPlugin LoadPlugin(string path);

    }
}

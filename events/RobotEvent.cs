using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.events {

    /// <summary>
    /// ARL内部传播的事件，可以继承该类并调用PluginManager的CallEvent方法，将事件传递至对应感兴趣的EventHandler
    /// </summary>
    public abstract class RobotEvent {

    }
}

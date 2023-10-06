using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.events {

    /// <summary>
    /// 在IEventList实现类中标记了该属性的方法，ARL将会根据其方法的参数（RobotEvent），传递对应的事件
    /// </summary>

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EventHandler : Attribute{

    }

}

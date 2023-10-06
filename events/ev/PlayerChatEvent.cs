using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.events.ev {
    public class PlayerChatEvent : RobotEvent {

        public string speaker;
        public string message;

    }
}

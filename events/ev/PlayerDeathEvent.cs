using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.events.ev {
    public class PlayerDeathEvent : RobotEvent {

        public string killerPlatoon;
        public string killerName;

        public string killerBy;

        public string playerPlatoon;
        public string playerName;

    }
}

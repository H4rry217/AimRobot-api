using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.game {
    public struct PlayerStatInfo {

        public string userName { get; set; }
        public long id { get; set; }
        public int rank { get; set; }
        public double scorePerMinute { get; set; }
        public double killsPerMinute { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }

    }
}

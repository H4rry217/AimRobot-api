using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api {
    public interface IConnection {

        public void SendBuffer(byte[] buffer);

    }
}

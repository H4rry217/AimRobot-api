using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api {
    public interface IRobotLogger {

        void Debug(string s);

        void Info(string s);

        void Warn(string s);

        void Error(string s);

        void Fatal(string s);

    }
}

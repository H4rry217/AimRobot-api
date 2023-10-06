using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.command {

    /// <summary>
    /// 指令元数据，包含发送者的名字，以及发送者输入指令时的附带参数
    /// </summary>
    public class CommandData {

        protected readonly Dictionary<string, string> commandParams;
        protected readonly string commandSender;

        public CommandData(Dictionary<string, string> pairs, string sender) { 
            commandParams = pairs;
            commandSender = sender;
        }

        public T GetValue<T>(string key) {
            return (T)Convert.ChangeType(commandParams[key], typeof(T));
        }

        /// <summary>
        /// 当返回null时则代表命令是从ARL的控制台直接发送的
        /// </summary>
        /// <returns></returns>
        public string GetSender() {
            return commandSender;
        }

    }
}

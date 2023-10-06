using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.command{

    public interface ICommandListener{

        /// <summary>
        /// ICommandListener所“订阅”的命令关键词
        /// </summary>
        /// <returns></returns>
        public string GetCommandKeyword();

        public enum CommandStyle {
            [Description("cmd=param")]
            Style1,

            [Description("cmd --paramKey=paramVal")]
            Style2,

            Unknown
        }

        /// <summary>
        /// 命令标识符
        /// </summary>
        public static readonly string CMD_SIGN = "!";

        /// <summary>
        /// 当有人输入命令刚好与GetCommandKeyword相同时，ARL将会分析对应的指令元数据CommandData，并传递至OnCommand方法
        /// </summary>
        /// <param name="commandHandler"></param>
        public void OnCommand(CommandData commandHandler);

    }

}

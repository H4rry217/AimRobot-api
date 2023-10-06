using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.game {
    public class GameConst {

        public static readonly string KILL_BY_SUICIDE = "suicide";

        public static readonly IReadOnlyCollection<string> TankCodes = new ReadOnlyCollection<string>(new List<string> { 
            //日本
            "Pac_ChiHa",
            "Chi-Ha_RocketLauncher_DeployVersion",
            "Pac_KaMi",

            //美国
            "Pac_Sherman",
            "Sherman_Calliope_DeployVersion",
            "Pac_LVT",
            "Greyhound",

            //德国
            "PanzerIVWirbelwind", //四号AA
            "StugIV", //四号突击炮
            "tiger",
            "Puma",
            "PanzerIVTank_1",
            "Panzer38t",
            "Sturmtiger",

            //英国
            "ValentineAA",
            "valentine",
            "staghound",
            "churchill_MKVII",
            "ChurchillGunCarrierTank", //丘吉尔自行火炮
            "ArcherTankDestroyer",
            "ChurchillCrocodileTank",

            //炮车
            "M3_T48",
            "PakwagenHalftrack"
        });

        public static readonly IReadOnlyCollection<string> PlaneCodes = new ReadOnlyCollection<string>(new List<string> {
            "Pac_Zero",
            "Pac_Corsair",

            "BF109",
            "JU88A",
            "Stuka_JU-87_B-1",
            "Stuka_JU-87_B-2",
            "JU88_C",

            "Mustang",
            "A20",

            "SpitfirePlane_MX-Va",
            "SpitfirePlane_MX-Vb",
            "blenheim",
            "Mosquito",
            "Mosquito_FBMkVI"
        });

        public static readonly IReadOnlyCollection<string> StationaryWeaponCodes = new ReadOnlyCollection<string>(new List<string> {
            "Stationary_40mmAA",
            "FLAK38AA",
            "QF6Pounder",
        });

        public static readonly IReadOnlyCollection<string> RocketCodes = new ReadOnlyCollection<string>(new List<string> {
            "Ki-147_Rocket",
            "V1_Rocket"
        });

        public static readonly IReadOnlyDictionary<int, string> BfvRobotCommunityStatus = new ReadOnlyDictionary<int, string>( new Dictionary<int, string>() {
            {0, "数据正常"},
            {1, "举报证据不足[无效举报]"},
            {2, "武器数据异常"}, //
            {3, "全局黑名单[来自玩家的举报]"}, //
            {4, "全局白名单[刷枪或其它自证]"},
            {5, "全局白名单[Moss自证]"},
            {6, "当前数据正常(曾经有武器数据异常记录)"},
            {7, "全局黑名单[服主添加]"}, //
            {8, "永久全局黑名单[羞耻柱]"}, //
            {9, "永久全局黑名单[辱华涉政违法]"}, //
            {10, "全局黑名单[检查组添加]"}, //
            {11, "诈骗黑名单[不受欢迎的玩家]"}, //
            {12, "全局黑名单[机器人自动反外挂]"}, //
            {13, "全局黑名单[社区举报数据异常]"} //
        });

        public static readonly IReadOnlyDictionary<int, string> BfvRobotCommunityAbnormalStatus = new ReadOnlyDictionary<int, string>(new Dictionary<int, string>() {
            {2, "武器数据异常"},
            {3, "全局黑名单[来自玩家的举报]"},
            {7, "全局黑名单[服主添加]"}, //
            {8, "永久全局黑名单[羞耻柱]"}, //
            {9, "永久全局黑名单[辱华涉政违法]"}, //
            {10, "全局黑名单[检查组添加]"}, //
            {11, "诈骗黑名单[不受欢迎的玩家]"}, //
            {12, "全局黑名单[机器人自动反外挂]"}, //
            {13, "全局黑名单[社区举报数据异常]"} //
        });

    }
}

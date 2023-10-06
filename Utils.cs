using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api {
    public class Utils {

        public static string ReadArgName(string str) {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < str.Length; i++) {
                char chr = str[i];
                if (chr == '=' || chr == ' ') {
                    break;
                } else {
                    stringBuilder.Append(chr);
                }
            }

            return stringBuilder.ToString();
        }

        public static string ReadArgValue(string str) {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < str.Length; i++) {
                char chr = str[i];
                if (chr == '"') {
                    string strTemp = str.Substring(i + 1);
                    stringBuilder.Append(strTemp, 0, strTemp.IndexOf('"'));
                    break;
                } else if (chr != ' ') {
                    stringBuilder.Append(chr);
                } else {
                    break;
                }
            }

            return stringBuilder.ToString();
        }

        public static Dictionary<string, string> getArgs(string paramsString) {
            Dictionary<string, string> map = new Dictionary<string, string>();

            for (int i = 0; i < paramsString.Length;) {
                if (paramsString[i] == '-' && paramsString[i + 1] == '-') {
                    //arg identical
                    i += 2;
                    string argName = ReadArgName(paramsString.Substring(i));

                    i += argName.Length;
                    if (i == paramsString.Length) {
                        i--;
                        map[argName] = argName;
                    }

                    char chr = paramsString[i];
                    //判断是否是有值的
                    if (chr == ' ') {
                        map[argName] = argName;
                    } else if (chr == '=') {
                        i++;
                        string argVal = ReadArgValue(paramsString.Substring(i));
                        map[argName] = argVal;
                    }

                } else {
                    i++;
                }
            }

            return map;
        }

    }
}

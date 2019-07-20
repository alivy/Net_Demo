using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Interception.Utilities;

namespace Miao_ToolCase
{
    /// <summary>
    /// ip验证
    /// </summary>
    public class IPValidate
    {
        // private static string ipStrArry = "192.0.2.*;192.1.*.*"; //192.0.1.1;192.0.1.2,192.0.1.3,192.0.1.4,192.0.1.5,

        /// <summary>
        /// 输入ip地址
        /// </summary>
        private static string ip = "192.0.1.1;192.0.1.2,192.0.1.3,192.0.1.4,192.0.1.5,192.0.1.5";

        /// <summary>
        /// 验证输入ip格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string ValidateInputIP(string ip)
        {
            string msg = "";
            string[] ipArry = Regex.Split(ip, ";", RegexOptions.IgnoreCase);
            ipArry.ForEach(x => Console.WriteLine(x + "验证方法验证成功"));
            return msg;
        }

        /// <summary>
        /// 用户登录ip验证
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool ValidateLoginIP(string ipStr)
        {
            string ipString = "192.0.*.2;192.1.*.*";
            bool validate = false;
            string[] allowIpArry = Regex.Split(ipString, ";", RegexOptions.IgnoreCase);
            string[] ipStrArry = ipStr.Split('.');
            if (allowIpArry.Contains(ipStr) || allowIpArry.Equals("::1"))
                validate = true;
            else
            {
                allowIpArry = allowIpArry.Where(x => x.Contains("*")).ToArray();
                foreach (var item in allowIpArry)
                {
                    string[] itemSplitArry = item.Split('.');
                    int j = 0;
                    for (int i = 0; i < itemSplitArry.Length; i++)
                    {
                        var intervalIp = itemSplitArry[i];
                        var currentIp = ipStrArry[i];
                        if (intervalIp == "*" || intervalIp == currentIp)
                            j++;
                        else
                        {
                            j = 0;
                            break;
                        }
                    }
                    if (j == 4)
                    {
                        validate = true;
                        break;
                    }
                }
            }
            return validate;
        }


        public static bool ValidateLoginIp(string ipStr, string allowIp)
        {
            bool validate = false;
            string[] allowIpArry = Regex.Split(allowIp, ";", RegexOptions.IgnoreCase);
            string[] ipStrArry = ipStr.Split(':');
            if (allowIpArry.Contains(ipStr) || allowIpArry.Equals("::1"))
                validate = true;
            else
            {
                allowIpArry = allowIpArry.Where(x => x.Contains("*")).ToArray();
                foreach (var item in allowIpArry)
                {
                    string[] itemSplitArry = item.Split('.');
                    int j = 0;
                    for (int i = 0; i < itemSplitArry.Length; i++)
                    {
                        var intervalIp = itemSplitArry[i];
                        var currentIp = ipStrArry[i];
                        if (intervalIp == "*" || intervalIp == currentIp)
                            j++;
                        else
                        {
                            j = 0;
                            break;
                        }
                    }
                    if (j == 4)
                    {
                        validate = true;
                        break;
                    }
                }
            }
            return validate;
        }
    }
}

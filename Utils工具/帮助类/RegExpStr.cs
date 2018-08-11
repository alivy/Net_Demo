using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils工具
{
    /// <summary>
    /// 常用正则表达式字符串
    /// </summary>
    public static class RegExpStr
    {
        /// <summary>
        /// 中文
        /// </summary>
        public const string Chinese = @"^[\u0391-\uFFE5]+$";

        /// <summary>
        /// 号码
        /// </summary>
        public const string Mobile = @"^(0|86|17951)?(13[0-9]|15[012356789]|17[0-8]|18[0-9]|14[57])[0-9]{8}$";

        /// <summary>
        /// 邮箱
        /// </summary>
        public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";

        /// <summary>
        /// 手机号码或邮箱
        /// </summary>
        public const string EmailOrMobile = @"(^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$)|(^(0|86|17951)?(13[0-9]|15[012356789]|17[0-8]|18[0-9]|14[57])[0-9]{8}$)";
        /// <summary>
        /// 数字
        /// </summary>
        public const string Number = @"^[0-9]*$";

        /// <summary>
        /// 身份证
        /// </summary>
        public const string IDCard = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";

        /// <summary>
        /// 用户名
        /// </summary>
        public const string UserName = @"^[a-zA-Z0-9]+$";
    }
}

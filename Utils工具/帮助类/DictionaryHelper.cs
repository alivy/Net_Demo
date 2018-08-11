using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Utils工具
{
    public class DictionaryHelper
    {

        /// <summary>
        /// 将Dictionary转化为Url参数
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public static string DictionaryToUrlJsonParam(Dictionary<string, object> paramData)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in paramData)
            {
                if (item.Value != null && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    if (i > 0)
                    {
                        builder.Append("&");
                    }
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }  
            return builder.ToString();
        }

        /// <summary>
        /// 将SortedDictionary转化为Url参数
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public static string SortedDictionaryToUrlJsonParam(SortedDictionary<string, object> paramData)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in paramData)
            {
                if (item.Value != null && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    if (i > 0)
                    {
                        builder.Append("&");
                    }
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            return builder.ToString();
        }
    }
}

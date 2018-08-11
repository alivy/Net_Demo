using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.百度统计
{
    public class BaiduStatistic
    {
        /// <summary>
        /// 百度统计
        /// </summary>
        /// <returns></returns>
        public string Baidu_Statistic(string stutasday = "", string endday = "", string method = "", string metrics = "")
        {
            if (stutasday == "")
            {
                stutasday = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            }
            if (endday == "")
            {
                endday = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (method == "")
            {
                method = "overview/getDistrictRpt";
            }
            if (metrics == "")
            {
                metrics = "pv_count";
            }
            //分页
            int max_results = 20;
            //固定参数文件
            string token = "946ba06934cbac0a84ff8b2753b0bd67";  //开通统计接口Toke
            string username = "小严AAA";                        //
            string password = "yanhaomiao123";                  //密码
            string siteId = "11237535";                         //可通过getlist接口请求获取，或者打开站点末尾处有接siteId


            SortedDictionary<string, string> reqMap = new SortedDictionary<string, string>();
            //头文件集合
            SortedDictionary<string, string> map1 = new SortedDictionary<string, string>();
            map1.Add("account_type", "1");
            map1.Add("password", password);
            map1.Add("token", token);
            map1.Add("username", username);
            //内容文件集合
            SortedDictionary<string, string> map2 = new SortedDictionary<string, string>();
            map2.Add("siteId", siteId);
            map2.Add("method", method);                     //通常对应要查询的报告
            map2.Add("start_date", stutasday);              //开始时间
            map2.Add("end_date", endday);                   //结束时间
            map2.Add("metrics", metrics);                   //自定义指标选择，多个指标用逗号分隔
            map2.Add("max_results", max_results.ToString()); //一页显示多少条，默认0显示全部
            map2.Add("start_index ", "");                    //表示第几页，默认0

            reqMap.Add("body", JsonConvert.SerializeObject(map2));
            reqMap.Add("header", JsonConvert.SerializeObject(map1));

            var strJson = JsonConvert.SerializeObject(reqMap).Replace("\"{", "{").Replace("}\"", "}").Replace(@"\", "");
            var res = HttpPosts.Post("https://api.baidu.com/json/tongji/v1/ReportService/getData", strJson);
            //var Result = ToResult(res);
            return res;
        }

        //方法一
        //public static string ToResult(string res)
        //{
        //    //方法一
        //    ToResult tores = JsonConvert.DeserializeObject<ToResult>(res.ToString());
        //    var desc = tores.header.desc;
        //    var status = tores.header.status;
        //    if (desc == "success" && status == "0")
        //    {
        //        //此处将错误编号写入异常日志
        //        StringBuilder str = new StringBuilder();
        //        str.AppendLine("**********百度统计API请求*************");
        //        str.AppendLine("返回desc:" + desc.ToString());
        //        str.AppendLine("返回状态：" + status);
        //        str.AppendLine("**********百度统计API请求*************");
        //        return str.ToString();
        //    }
        //    //取得接口data数据
        //    List<Date> date = tores.body.data.ToList();
        //    //取得回传刷选数据
        //    string fields = date[0].result.fields.ToString().Replace("[", "").Replace("]", "");

        //    getDistrictRpt rpt = new getDistrictRpt();
        //    //城市集合
        //    string[] sArray = date[0].result.items.ToList()[0].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //    string[] sArray1 = date[0].result.items.ToList()[1].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        //    var arry = sArray.Length;
        //    var cc = "";
        //    for (int i = 0; i < arry; i++)
        //    {
        //        rpt.City = sArray[i].Replace("[", "").Replace("]", "").Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
        //        rpt.Proportion = sArray1[2 * i].Replace("[", "").Replace("]", "").Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
        //        rpt.Views = sArray1[2 * i + 1].Replace("[", "").Replace("]", "").Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
        //        cc += "城市：" + rpt.City + "点击量:" + rpt.Proportion + "访问占比:" + rpt.Views;
        //        Console.WriteLine(cc);
        //    }
        //    return cc;
        //}
    }
}

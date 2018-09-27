using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Knowledge_Point知识点.Cookie和Session
{
    /// <summary>
    /// 讲述Cookie和Session使用以及区别
    /// </summary>
    public class Distinction
    {
        /// <summary>
        /// Cookie基本使用
        /// </summary>
        public void UseCookie()
        {
            {
                HttpCookie cookie = new HttpCookie("UserId");
                cookie.Value = "蝈蝈";
                HttpCookie cookie1 = new HttpCookie("UserId", "蝈蝈");
                cookie.Expires = DateTime.Now.AddMinutes(2);
                HttpContext.Current.Response.AppendCookie(cookie);
                HttpContext.Current.Response.Cookies.Add(cookie1);
            }
            {
                HttpContext.Current.Response.Cookies["Pwd"].Value = "123456";
                //设置访问过期时间
                HttpContext.Current.Response.Cookies["Pwd"].Expires = DateTime.Now.AddMinutes(2);
            }
            {
                string value = GetCookie("Pwd");

                UpdateCookie("Pwd", "12345678");
                value = GetCookie("Pwd");

                UpdateCookieDate("Pwd", 10);
                value = GetCookie("Pwd");

                DelteCookie("Pwd");
                value = GetCookie("Pwd");

            }

        }

        /// <summary>
        /// Cookie升级使用(多级Cookie)
        /// </summary>

        public void UpUseCookie() {

            {
                HttpCookie cookie = new HttpCookie("Guo", "MainCookieValue");
                //HttpCookie cookie = new HttpCookie("Guo");
                //cookie.Value = "MainCookieValue";
                cookie.Expires = DateTime.Now.AddMinutes(2);
                cookie.Values["Age"] = "18";
                cookie.Values["Name"] = "蝈蝈";
                cookie.Values.Add("Phone", "18233399999");
                HttpContext.Current.Response.Cookies.Add(cookie);
                //string value = HttpContext.Current.Request.Cookies["Guo"].Value;
                //value == MainCookieValue&Age=18&Name=蝈蝈&Phone=18233399999
            }
            {
                //读取
                string key = "Age";
                string subKey = "Name";
                string Values = "";
                if (HttpContext.Current.Request.Cookies[key] != null)
                {
                    Values = HttpContext.Current.Request.Cookies[key][subKey] ?? "不存在键：" + key + "->" + subKey;
                }
                else
                {
                    Values ="不存在键：" + key;
                }

            }
            {
                string key = "Age";
                string subKey = "Name";
                string Values = "";
                if (HttpContext.Current.Request.Cookies[key] != null)
                {
                    Values = HttpContext.Current.Request.Cookies[key][subKey] ?? "不存在键：" + key + "->" + subKey;
                }
                else
                {
                    Values = "不存在键：" + key;
                }
            }
            {
                //删除
                HttpContext.Current.Request.Cookies["Guo"].Values.Remove("Age");
                //除之后HttpContext.Current.Request.Cookies[“Guo”][“Age”]或HttpContext.Current.Request.Cookies[“Guo”].Values[“Age”]还是能读取到，
                //设置Expires属性为过去某一时间即可起到删除的效果
            }
        }

        /// <summary>
        /// Session基本使用
        /// </summary>
        public void UseSession()
        {
            {
                //创建
                HttpContext.Current.Session["UserID"] = "abc";
                HttpContext.Current.Session["Pwd"] = "123";
            }
            {
                //读取
                string name = "UserID";
                string result = "Session[" + name + "]不存在¨²";
                if (HttpContext.Current.Session[name] != null)
                {
                    result = HttpContext.Current.Session[name].ToString();
                }
            }
            {
                ///修改
                string msg = string.Empty;
                string key = "Pwd";
                string value = "123456";
                if (HttpContext.Current.Session[key] != null)
                {
                    HttpContext.Current.Session[key] = value; //存在修改
                }
                else
                {
                    HttpContext.Current.Session[key] = value; //不存在添加
                    msg = "Session[" + key + "]==null";
                }
            }
            {
                //删除
                string key = "Pwd";
                HttpContext.Current.Session.Remove(key);
                string value = HttpContext.Current.Session[key].ToString();
            }
            {
                // 设置过期时间
                //页面级的TimeOut优先级高于Web.Config中设置的timeout
                HttpContext.Current.Session.Timeout = 3;
                //< sessionState mode = "InProc" timeout = "1" ></ sessionState >
                //在ashx文件中使用Session需要引用using System.Web.SessionState;，然后实现IrequiresSessionState接口， 
                //不然执行context.Session.TimeOut = 1; 时一直报“错误：Session = null”
            }




        }


        #region Cookie操作
        /// <summary>
        ///读取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookie(string key)
        {

            string value = string.Empty;
            //读取
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                value = HttpContext.Current.Request.Cookies[key].ToString();
            }
            else
            {
                value = "不存在键：" + key;
            }

            return value;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="key"></param>
        public void UpdateCookie(string key, string value)
        {
            try
            {

                if (HttpContext.Current.Request.Cookies[key] != null && string.IsNullOrEmpty(value))
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
                    cookie.Value = value; //必须判空
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
            catch (Exception e)
            {

                throw e;
            }


        }
        /// <summary>
        /// 更新过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="time">分钟</param>
        public void UpdateCookieDate(string key, int time)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
                cookie.Expires = DateTime.Now.AddMinutes(time);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public void DelteCookie(string key)
        {
            string value = string.Empty;
            //读取
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpContext.Current.Request.Cookies.Remove(key);

            }
            else
            {
                value = "不存在键：" + key;
            }
        }
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Utils工具
{
    public class SessionManager
    {
        #region 向当前会话状态集合添加一个新项

        /// <summary>
        /// 向当前会话状态集合添加一个新项
        /// </summary>
        /// <param name="name">会话名称</param>
        /// <param name="value">会话值</param>
        public static void Add(string name, object value)
        {
            HttpContext.Current.Session.Add(name, value);
        }

        /// <summary>
        /// 向当前会话状态集合添加一个新项，并设置TimeOut
        /// </summary>
        /// <param name="name">会话名称</param>
        /// <param name="value">会话值</param>
        /// <param name="timeOut">超时时间，以分钟为单位</param>
        public static void Add(string name, object value, int timeOut)
        {
            HttpContext.Current.Session.Add(name, value);
            HttpContext.Current.Session.Timeout = timeOut;
        }
        #endregion

        #region 根据会话名称获取会话值

        /// <summary>
        /// 根据会话名称获取会话值
        /// </summary>
        /// <param name="name">会话名称</param>
        /// <returns>返回会话值</returns>
        public static object Get(string name)
        {
            return HttpContext.Current.Session[name];
        }
        #endregion

        #region 获取当前会话的唯一标识符

        /// <summary>
        /// 获取当前会话的唯一标识符
        /// </summary>
        /// <returns></returns>
        public static string SessionID()
        {
            return HttpContext.Current.Session.SessionID;
        }
        #endregion

        #region 设置当前会话状态的超时时间，以分钟为单位

        /// <summary>
        /// 设置当前会话状态的超时时间，以分钟为单位
        /// </summary>
        /// <param name="timeOut">超时时间</param>
        public static void SetTimeOut(int timeOut)
        {
            HttpContext.Current.Session.Timeout = timeOut;
        }
        #endregion

        #region 根据会话名称删除会话
        /// <summary>
        /// 根据会话名称删除会话
        /// </summary>
        /// <param name="name">会话名称</param>
        public static void Remove(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }
        #endregion

        #region 从当前会话状态集合中移除所有的键和值

        /// <summary>
        /// 从当前会话状态集合中移除所有的键和值
        /// </summary>
        public static void clear()
        {
            HttpContext.Current.Session.Clear();
        }
        #endregion
    }



    public class CookiesManager
    {
        /// <summary>
        /// 向当前会话状态集合添加一个新项
        /// </summary>
        /// <param name="name">会话名称</param>
        /// <param name="value">会话值</param>
        /// <param name="dtTime">过期时间</param>
        public static void Add(string name, string value, DateTime dtTime)
        {
            //添加Cookie
            HttpCookie m_cookie = new HttpCookie(name);
            m_cookie.Value = value;
            m_cookie.Expires = dtTime;
            HttpContext.Current.Response.Cookies.Add(m_cookie);
        }

        /// <summary>
        /// 根据会话名称获取会话值
        /// </summary>
        /// <param name="name">会话名称</param>
        /// <returns>返回会话值</returns>
        public static object Get(string name)
        {
            string obj = null;
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                obj = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies[name].Value);
            }
            return obj;
        }


        /// <summary>
        /// 根据会话名称删除会话
        /// </summary>
        /// <param name="name">会话名称</param>
        /// <param name="value">值</param>
        /// <param name="dtTime">过期时间</param>
        public static void Remove(string name, string value, DateTime dtTime)
        {
            HttpCookie m_cookie = HttpContext.Current.Request.Cookies[name];
            m_cookie.Values.Remove(value);
            m_cookie.Expires = dtTime;
            HttpContext.Current.Response.Cookies.Add(m_cookie);
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Collections.Specialized;
using OptimizeReflection;

namespace MyCore
{
    public static class ActionExecutors
    {
        public static object ExecuteAction(string _DataContent, InvokeInfo vkInfo)
        {

            if (vkInfo == null)
                throw new ArgumentNullException("vkInfo");

            // 调用方法
            object result = ExecuteActionInternal(_DataContent, vkInfo);
            return result;
        }

        internal static object ExecuteActionInternal(string _DataContent, InvokeInfo info)
        {
            // 准备要传给调用方法的参数
            object[] parameters = GetActionCallParameters(_DataContent, info.Action);

            // 调用方法
            if (info.Action.HasReturn)
                //return info.Action.MethodInfo.Invoke(info.Instance, parameters);
                return info.Action.MethodInfo.FastInvoke(info.Instance, parameters);

            else
            {
                //info.Action.MethodInfo.Invoke(info.Instance, parameters);
                info.Action.MethodInfo.FastInvoke(info.Instance, parameters);
                return null;
            }
        }


        private static object[] GetActionCallParameters(string _DataContent, ActionDescription action)
        {
            if (action.Parameters == null || action.Parameters.Length == 0)
                return null;

            return GetParameters(_DataContent, action);
        }

        public static object[] GetParameters(string _DataContent, ActionDescription action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            var meths = action.Parameters;
            Object[] params_obj = new Object[meths.Length];
            for (int i = 0; i < meths.Length; i++)
            {
                var mtype = meths[i].Name;
                if (mtype == "json")
                {
                    params_obj[i] = _DataContent;
                    continue;
                }

                if (meths[i].IsOut)
                    continue;

                if (meths[i].ParameterType == typeof(VoidType))
                    continue;

                var value = GetValue(_DataContent, mtype);
                if (value == null)
                {
                    throw new ArgumentException("为讲对象引用到实例，参数：" + mtype);
                }
                string val = value.ToString();

                Type ptype = meths[i].ParameterType;

                // 如果参数是可支持的类型，则直接从HttpRequest中读取并赋值
                if (ptype.GetRealType().IsSupportableType())
                {
                    params_obj[i] = Convert.ChangeType(val, ptype);
                }
                else
                {
                    params_obj[i] = JsonConvert.DeserializeObject(val, ptype);
                }
            }
            return params_obj;
        }
        //找到对应key的值
        public static object GetValue(string param, string fields)
        {
            var jObject = JObject.Parse(param);
            object obj = jObject[fields];
            if (obj != null)
            {
                return obj; //获取属性值
            }
            return null;
        }
    }
}

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
    public static class ActionExecutor
    {
        public static object ExecuteAction(BaseParam param, InvokeInfo vkInfo)
        {

            if (vkInfo == null)
                throw new ArgumentNullException("vkInfo");

            // 调用方法
            object result = ExecuteActionInternal(param, vkInfo);

            //// 处理方法的返回结果
            //IActionResult executeResult = result as IActionResult;
            //if( executeResult != null ) {
            //    executeResult.Ouput(context);
            //}
            //else {
            //    if( result != null ) {
            //        // 普通类型结果
            //        context.Response.ContentType = "text/plain";
            //        context.Response.Write(result.ToString());
            //    }
            //}
            return result;
        }

        internal static object ExecuteActionInternal(BaseParam param, InvokeInfo info)
        {
            // 准备要传给调用方法的参数
            object[] parameters = GetActionCallParameters(param, info.Action);

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


        private static object[] GetActionCallParameters(BaseParam param, ActionDescription action)
        {
            if (action.Parameters == null || action.Parameters.Length == 0)
                return null;

            return GetParameters(param, action);
        }

        public static object[] GetParameters(BaseParam param, ActionDescription action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            object[] parameters = new object[action.Parameters.Length];

            for (int i = 0; i < action.Parameters.Length; i++)
            {
                ParameterInfo p = action.Parameters[i];

                if (p.IsOut)
                    continue;

                if (p.ParameterType == typeof(VoidType))
                    continue;


                Type paramterType = p.ParameterType.GetRealType();

                // 如果参数是可支持的类型，则直接从HttpRequest中读取并赋值
                if (paramterType.IsSupportableType())
                {
                    //var a = param[""];
                    object val = GetValue(param, p.Name);
                    if (val != null)
                        parameters[i] = val;
                    else
                    {
                        if (p.ParameterType.IsValueType && p.ParameterType.IsNullableType() == false)
                            throw new ArgumentException("未能找到指定的参数值：" + p.Name);
                    }
                }
                else
                {
                    throw new ArgumentException("暂不支持该类型：" + p.ParameterType.ToString());
                    //ModelHelper.FillModel(request, item, p.Name);
                    //parameters[i] = Convert.ChangeType(item, paramterType);
                    //parameters[i] = item;
                    //parameters[i] = null;
                }
            }
            return parameters;
        }

        public static object GetValue(BaseParam param, string fields)
        {
            Type type = param.GetType(); //获取类型
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(fields); //获取指定名称的属性
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(param, null); //获取属性值
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Utils工具.Model验证
{
    public static class ModelValid
    {




        /// <summary>
        /// 获取验证结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool GetIsValid<T>(this T t) where T : new()
        {
            return GetValidMode(t).IsValid;
        }





        /// <summary>
        /// 根据类型获取表名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static ModelValidMsg GetModelValid<T>(this T t) where T : new()
        {
            return GetValidMode(t);
        }

        /// <summary>
        /// 验证合法性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        private static ModelValidMsg GetValidMode<T>(T t)
        {
            var modelMsg = new ModelValidMsg();
            Type type = t.GetType();
            try
            {
                foreach (var property in type.GetProperties())
                {
                    object[] oAttributeList = property.GetCustomAttributes(true);
                    foreach (var item in oAttributeList)
                    {
                        var attribute = item as ValidationAttribute;
                        if (attribute == null)
                            continue;
                        var isValid = attribute.IsValid(property.GetValue(t));
                        if (!isValid)
                        {
                            modelMsg.IsValid = false;
                            modelMsg.ErrorMessage = attribute.ErrorMessage;
                            return modelMsg;
                        }
                    }
                }
                modelMsg.IsValid = true;
                modelMsg.ErrorMessage = "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return modelMsg;
        }




    }

    /// <summary>
    /// 验证错误消息
    /// </summary>
    public class ValidErrorMessage
    {
        /// <summary>
        /// 验证是否通过
        /// </summary>
        public string Key { get; set; }

        // 摘要:
        //     获取或设置一条在验证失败的情况下与验证控件关联的错误消息。
        //
        // 返回结果:
        //     与验证控件关联的错误消息。
        public string ErrorMessage { get; set; }
    }


    public class ModelValidMsg
    {
        /// <summary>
        /// 验证是否通过
        /// </summary>
        public bool IsValid { get; set; }

        // 摘要:
        //     获取或设置一条在验证失败的情况下与验证控件关联的错误消息。
        //
        // 返回结果:
        //     与验证控件关联的错误消息。
        public string ErrorMessage { get; set; }

    }
}

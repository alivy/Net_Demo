using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyCore
{
    class ValidateHelper
    {
        /// <summary>
        /// 检查需要验证的函数是否通过
        /// </summary>
        /// <param name="checkType">被检查类型</param>
        /// <param name="matchType">需要检查的类型</param>
        /// <param name="func">检查函数</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns>Emtpy 验证通过，否则返回错误信息</returns>
        private static string CheckValidate(ValidateType checkType, ValidateType matchType, Func<bool> func, string errMessage)
        {
            if (checkType.HasFlag(matchType))
            {
                if (func())
                {
                    return errMessage;
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// 检查对象是否通过验证
        /// </summary>
        /// <param name="entityObject">需要检查的对象</param>
        /// <param name="errMessage">返回错误信息</param>
        /// <returns>true:通过，false：失败</returns>
        public static bool GetValidateResult(object entityObject, out Dictionary<string, string> validateError)
        {
            validateError = new Dictionary<string, string>();

            Type type = entityObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            string validateResult = string.Empty;

            string displayName = string.Empty;
            foreach (PropertyInfo property in properties)
            {
                displayName = property.Name;
                object[] validateContent = property.GetCustomAttributes(typeof(ValidateAttribute), true);
                object[] display = property.GetCustomAttributes(typeof(DisplayAttribute), true);
                if (display.Length > 0)
                {
                    displayName = (display[0] as DisplayAttribute).Name;
                }
                if (validateContent != null)
                {
                    object value = property.GetValue(entityObject, null);
                    //var validateObj = validateContent.OrderBy(m => m).ToList();
                    foreach (ValidateAttribute validateAttribute in validateContent)
                    {
                        IList<ValidateModel> condition = new List<ValidateModel>();
                        //需要什么验证，在这里添加
                        if (validateAttribute.ValidateType == ValidateType.NotEmpty)
                        {
                            condition.Add(new ValidateModel { Type = ValidateType.NotEmpty, CheckFunc = () => { return (value == null || value.ToString().Length < 1); }, ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}不能为空。", displayName) });
                            if(value.GetType()==typeof(DateTime))
                            {
                                condition.Add(new ValidateModel { Type = ValidateType.NotEmpty, CheckFunc = () => { return (value == null || value.ToString().Length < 1) || value.ToString() == "0001/1/1 0:00:00"; }, ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}不能为空。", displayName) });
                            
                            }
                        }
                        if (validateAttribute.ValidateType == ValidateType.MaxLength)
                        {
                            condition.Add(new ValidateModel { Type = ValidateType.MaxLength, CheckFunc = () => { return (value.ToString().Length > validateAttribute.MaxLength); }, ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}长度不能超过{1}", displayName, validateAttribute.MaxLength) });
                        }
                        if (validateAttribute.ValidateType == ValidateType.MinLength)
                        {
                            condition.Add(new ValidateModel { Type = ValidateType.MinLength, CheckFunc = () => { return (value.ToString().Length < validateAttribute.MinLength); }, ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}长度不能小于{1}", displayName, validateAttribute.MinLength) });
                        }
                        //condition.Add(new ValidateModel { Type = ValidateType.Regx, CheckFunc = () => { return (!(value != null && !string.IsNullOrWhiteSpace(validateAttribute.Pattern) && System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), validateAttribute.Pattern))); }, ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}有误", property.Name) });
                        if (validateAttribute.ValidateType == ValidateType.Regx)
                        {
                            condition.Add(new ValidateModel
                            {
                                Type = ValidateType.Regx,
                                CheckFunc = () =>
                                {
                                    ValidateAttribute attr = ((ValidateAttribute[])validateContent).Where(m => m.ValidateType == ValidateType.NotEmpty).FirstOrDefault();
                                    if (attr == null)
                                    {
                                        return false;
                                    }
                                    return (!(value != null && value.ToString() != "" && !string.IsNullOrWhiteSpace(validateAttribute.Pattern) && System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), validateAttribute.Pattern)));
                                },
                                ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}有误", property.Name)
                            });
                        }

                        //condition.Add(new ValidateModel { Type = ValidateType.IsPhone, CheckFunc = () => { return (!(value != null && System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), @"^\d+$"))); }, ErrorMessage = validateAttribute.ErrorMessage ?? String.Format("{0}必须是电话号码", displayName) });

                        foreach (ValidateModel model in condition)
                        {
                            validateResult = CheckValidate(
                                    validateAttribute.ValidateType,
                                    model.Type,
                                    model.CheckFunc,
                                    model.ErrorMessage
                            );
                            if (!string.IsNullOrEmpty(validateResult))
                            {
                                if (!validateError.ContainsKey(property.Name))
                                    validateError.Add(property.Name, validateResult);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}

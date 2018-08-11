using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCore
{
    public class BaseModel
    {
        /// <summary>
        /// 异常集合
        /// </summary>
        private Dictionary<string, string> validateError;

        public bool IsValid()
        {
            return ValidateHelper.GetValidateResult(this, out validateError);
        }

        public Dictionary<string, string> ToFormErrorMsg()
        {
            if (validateError == null)
                return new Dictionary<string, string>();
            return validateError;
        }
    }
}

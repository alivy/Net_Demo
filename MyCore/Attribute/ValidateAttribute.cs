using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCore
{
    [Flags]
    public enum ValidateType
    {
        NotEmpty = 1,
        MaxLength = 2,
        MinLength = 4,
        Regx = 8
        //Regx = 16
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ValidateAttribute : Attribute
    {
        public ValidateAttribute(ValidateType validateType)
        {
            ValidateType = validateType;
        }
        public ValidateType ValidateType { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string Pattern { get; set; }
        public string ErrorMessage { get; set; }
        public string[] CustomArray { get; set; }
    }
}

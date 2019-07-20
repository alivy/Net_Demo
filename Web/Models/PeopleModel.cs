using System;
using System.ComponentModel.DataAnnotations;


namespace Web.Models
{
    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            _Remark = remark;
        }

        private string _Remark;

        public string Remark
        {
            get
            {
                return _Remark;
            }
        }
    }

    /// <summary>
    /// 这里将指定PeopleModel自身的Required、StringLength等验证通过后，再进行PeopleModelVaildation中的CheckModel验证
    /// </summary>
    [CustomValidation(typeof(PeopleModelVaildation), "CheckModel")]
    public class PeopleModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Remark("123")]
        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "姓名的长度为{2}至{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Required(ErrorMessage = "年龄不能为空")]
        [Range(18, 60, ErrorMessage = "年龄的范围在{1}至{2}之间")]
        public string Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "性别不能为空")]
        public string Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Required(ErrorMessage = "生日不能为空")]
        public DateTime Brithday { get; set; }
    }
    /// <summary>
    /// 这个验证在实体内部的验证通过后，才会执行
    /// </summary>
    public class PeopleModelVaildation
    {
        public static ValidationResult CheckModel(object value, ValidationContext validationContext)
        {
            ///如果value是PeopleModel的实体类型，则验证value中指定的数据类型。
            if (value is PeopleModel item)
            {
                ///验证生日
                if (item.Brithday > DateTime.Now)
                {
                    return new ValidationResult("生日信息错误");
                }
            }
            //验证成功
            return ValidationResult.Success;
        }
    }
}
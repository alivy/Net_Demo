using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCore
{
    /// <summary>
    /// 将一个方法标记为一个Action
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ActionAttribute : Attribute
    {
        public string ActionName { get; set; }

        public ActionAttribute() { }

        public ActionAttribute(string ActionName)
        {
            this.ActionName = ActionName;
        }
    }
}

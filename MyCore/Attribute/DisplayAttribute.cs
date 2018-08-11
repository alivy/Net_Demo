using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCore
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DisplayAttribute : Attribute
    {
        public string Name { get; set; }
    }
}

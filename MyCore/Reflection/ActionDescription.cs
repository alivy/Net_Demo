using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyCore
{
    public sealed class ActionDescription : BaseDescription
	{
        public BusinessDescription Business;
		public MethodInfo MethodInfo { get; private set; }
		public ParameterInfo[] Parameters { get; private set; }
		public bool HasReturn { get; private set; }

		public ActionDescription(MethodInfo m)
			: base(m)
		{
			this.MethodInfo = m;
			//this.Attr = atrr;
			this.Parameters = m.GetParameters();
			this.HasReturn = m.ReturnType != ReflectionHelper.VoidType;
		}
	}

}

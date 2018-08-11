using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCore
{
    public sealed class BusinessDescription : BaseDescription
	{
		public Type BusinessType { get; private set; }

        public BusinessDescription(Type t)
			: base(t)
		{
            this.BusinessType = t;
		}
	}


}

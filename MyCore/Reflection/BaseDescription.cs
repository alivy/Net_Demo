using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyCore
{
    public class BaseDescription
	{
		protected BaseDescription(MemberInfo m)
		{
			//this.Authorize = m.GetMyAttribute<AuthorizeAttribute>(true /* inherit */);
		}
	}



}

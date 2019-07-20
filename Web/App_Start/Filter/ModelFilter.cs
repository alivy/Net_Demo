using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace Web.App_Start.Filter
{
    /// <summary>
    /// 实体验证过滤器
    /// 需要在Starup.cs中的ConfigureServices中注册
    /// </summary>
    public class ModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
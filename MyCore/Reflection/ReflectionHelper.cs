using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Web.Compilation;
using System.Web;
using OptimizeReflection;
using System.Xml;
using MyCore;

namespace MyCore
{
    public  class ReflectionHelper
    {
        public static readonly Type VoidType = typeof(void);

        // 保存PageAction的字典
        public static Dictionary<string, ActionDescription> s_PageActionDict = new Dictionary<string, ActionDescription>();

        public ReflectionHelper()
        {
            InitControllers();
        }

        /// <summary>
        /// 加载所有的Controller
        /// </summary>
        public static void InitControllers()
        {
            s_PageActionDict = new Dictionary<string, ActionDescription>(4096, StringComparer.OrdinalIgnoreCase);

            //var businessTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IBusiness)))).ToArray();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Type[] businessTypes = new Type[1024];
            Type[] tmpTypes = new Type[1024];
            foreach (Assembly assembly in assemblies)
            {
                if (assembly.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (assembly.FullName.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase))
                    continue;

                tmpTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IBusiness))).ToArray();
                if (tmpTypes.Length > 0)
                    Array.Copy(tmpTypes, businessTypes, tmpTypes.Length);
            }

            string actionName = string.Empty;
            foreach (var business in businessTypes)
            {
                if (business == null)
                    continue;

                if (business.IsClass == false)
                    continue;

                var actions = business.GetMethods().ToList<MethodInfo>();
                foreach (var action in actions)
                {
                    var attrName = action.GetCustomAttributes(typeof(ActionAttribute), false).FirstOrDefault() as ActionAttribute;
                    if (attrName != null)
                    {
                        actionName = string.IsNullOrEmpty(attrName.ActionName) ? action.Name : attrName.ActionName;
                        if (!s_PageActionDict.ContainsKey(actionName))
                        {
                            s_PageActionDict.Add(actionName, new ActionDescription(action) { Business = new BusinessDescription(business) });
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 根据方法名称，返回内部表示的调用信息。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static InvokeInfo GetActionInvokeInfo(string name)
        {
            if (s_PageActionDict == null || s_PageActionDict.Count<=0)
            {
                InitControllers();
            }
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            ActionDescription action = null;
            if (s_PageActionDict.TryGetValue(name, out action) == false)
                return null;

            InvokeInfo vkInfo = new InvokeInfo();
            vkInfo.Business = action.Business;
            vkInfo.Action = action;

            if (vkInfo.Action.MethodInfo.IsStatic == false)
                //vkInfo.Instance = Activator.CreateInstance(vkInfo.Controller.ControllerType);
                vkInfo.Instance = vkInfo.Business.BusinessType.FastNew();

            return vkInfo;
        }
    }
}

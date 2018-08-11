using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace OptimizeReflection
{

	/// <summary>
	/// 一些扩展方法，用于反射操作，它们都可以优化反射性能。
	/// </summary>
	public static class ReflectionExtensions
	{
		private static readonly Hashtable s_getterDict = Hashtable.Synchronized(new Hashtable(10240));
		private static readonly Hashtable s_setterDict = Hashtable.Synchronized(new Hashtable(10240));
		private static readonly Hashtable s_methodDict = Hashtable.Synchronized(new Hashtable(10240));


		public static object FastNew(this Type instanceType)
		{
			if( instanceType == null )
				throw new ArgumentNullException("instanceType");

			CtorDelegate ctor = (CtorDelegate)s_methodDict[instanceType];
			if( ctor == null ) {
				ConstructorInfo ctorInfo = instanceType.GetConstructor(Type.EmptyTypes);
				ctor = DynamicMethodFactory.CreateConstructor(ctorInfo);
				s_methodDict[instanceType] = ctor;
			}

			return ctor();
		}
	}
}

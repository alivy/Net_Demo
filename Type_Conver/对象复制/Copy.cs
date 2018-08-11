using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conver
{
    public class Copy
    {
        public Copy()
        {
            Student s = new Student() { Age = 20, Id = 1, Name = "Emrys" };
            StudentSecond ss = TransExpV2<Student, StudentSecond>.Trans(s);

            //序列化转换对象，效率不高
            StudentSecond json_ss = JsonConvert.DeserializeObject<StudentSecond>(JsonConvert.SerializeObject(s));
        }

        /// <summary>
        /// 直接对象复制
        /// </summary>
        public S CopyModel<T, S>(T from, S m_record)
        {
            PropertyDescriptorCollection fromProperties = TypeDescriptor.GetProperties(from);
            PropertyDescriptorCollection toProperties = TypeDescriptor.GetProperties(m_record);

            foreach (PropertyDescriptor fromProperty in fromProperties)
            {
                PropertyDescriptor toProperty = toProperties.Find(fromProperty.Name, true /* ignoreCase */);
                if (toProperty != null && !toProperty.IsReadOnly)
                {

                    bool isDirectlyAssignable = toProperty.PropertyType.IsAssignableFrom(fromProperty.PropertyType);

                    bool liftedValueType = (isDirectlyAssignable) ? false : (Nullable.GetUnderlyingType(fromProperty.PropertyType) == toProperty.PropertyType);

                    if (isDirectlyAssignable || liftedValueType)
                    {
                        object fromValue = fromProperty.GetValue(from);
                        if (isDirectlyAssignable || (fromValue != null && liftedValueType))
                        {
                            toProperty.SetValue(m_record, fromValue);
                        }
                    }
                }
            }
            return m_record;
        }

        /// <summary>
        /// 反射获取属性和设置属性的值对象复制
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        private static TOut TransReflection<TIn, TOut>(TIn tIn)
        {
            TOut tOut = Activator.CreateInstance<TOut>();
            var tInType = tIn.GetType();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var itemIn = tInType.GetProperty(itemOut.Name); ;
                if (itemIn != null)
                {
                    itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                }
            }
            return tOut;
        }
    }
    /// <summary>
    /// 利用泛型的特性对象复制(最高效率)
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public static class TransExpV2<TIn, TOut>
    {
        private static readonly Func<TIn, TOut> cache = GetFunc();
        private static Func<TIn, TOut> GetFunc()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();

            foreach (var item in typeof(TOut).GetProperties())
            {
                if (!item.CanWrite)
                    continue;
                MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

            return lambda.Compile();
        }
        /// <summary>
        /// 表达式树进行处理
        /// </summary>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static TOut Trans(TIn tIn)
        {
            return cache(tIn);
        }

    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class StudentSecond
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

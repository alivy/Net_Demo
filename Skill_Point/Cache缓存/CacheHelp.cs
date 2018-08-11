using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;


namespace Skill_Point
{
    public class CacheHelper
    {
        /// <summary>
        /// 读取缓存数据
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache.Get(cacheKey);
            return objCache;
        }

        /// <summary>
        /// 设置缓存数据
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="content">值</param>
        public static void SetCache(string cacheKey, object content)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, content);
        }

        /// <summary>
        /// 设置缓存数据并且设置默认过期时间
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="content"></param>
        /// <param name="timeOut"></param>
        public static void SetCache(string cacheKey, object content, int timeOut = 3600)
        {
            try
            {
                if (content == null)
                {
                    return;
                }
                var objCache = HttpRuntime.Cache;
                //设置绝对过期时间
                //绝对时间过期。DateTime.Now.AddSeconds(10)表示缓存在3600秒后过期，TimeSpan.Zero表示不使用平滑过期策略。
                objCache.Insert(cacheKey, content, null, DateTime.Now.AddSeconds(timeOut), TimeSpan.Zero, CacheItemPriority.High, null);
                //相对过期
                //DateTime.MaxValue表示不使用绝对时间过期策略，TimeSpan.FromSeconds(10)表示缓存连续10秒没有访问就过期。
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 移除指定缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static void RemoveAllCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Remove(cacheKey);
        }

        /// <summary>
        /// 删除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            var objCache = HttpRuntime.Cache;
            var cacheEnum = objCache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                objCache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
   
    // 实现用于 Web 应用程序的缓存。无法继承此类。
//    public sealed class Cache : IEnumerable
//    {
//        // 用于 Cache.Insert(...) 方法调用中的 absoluteExpiration 参数中以指示项从不过期。
//        public static readonly DateTime NoAbsoluteExpiration;

//        // 用作 Cache.Insert(...) 或 Cache.Add(...)
//        //       方法调用中的 slidingExpiration 参数，以禁用可调过期。
//        public static readonly TimeSpan NoSlidingExpiration;


//        // 获取或设置指定键处的缓存项。
//        public object this[string key] { get; set; }


//        // 将指定项添加到 System.Web.Caching.Cache 对象，该对象具有依赖项、过期和优先级策略
//        // 以及一个委托（可用于在从 Cache 移除插入项时通知应用程序）。
//        public object Add(string key, object value, CacheDependency dependencies,
//                            DateTime absoluteExpiration, TimeSpan slidingExpiration,
//                            CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);


//        // 从 System.Web.Caching.Cache 对象检索指定项。
//        // key: 要检索的缓存项的标识符。
//        // 返回结果: 检索到的缓存项，未找到该键时为 null。
//        public object Get(string key);


//        public void Insert(string key, object value);
//        public void Insert(string key, object value, CacheDependency dependencies);
//        public void Insert(string key, object value, CacheDependency dependencies,
//                                        DateTime absoluteExpiration, TimeSpan slidingExpiration);

//        // 摘要:
//        //     向 System.Web.Caching.Cache 对象中插入对象，后者具有依赖项、过期和优先级策略
//        //        以及一个委托（可用于在从 Cache 移除插入项时通知应用程序）。
//        //
//        // 参数:
//        //   key:
//        //     用于引用该对象的缓存键。
//        //
//        //   value:
//        //     要插入缓存中的对象。
//        //
//        //   dependencies:
//        //     该项的文件依赖项或缓存键依赖项。当任何依赖项更改时，该对象即无效，
//        //            并从缓存中移除。如果没有依赖项，则此参数包含 null。
//        //
//        //   absoluteExpiration:
//        //     所插入对象将过期并被从缓存中移除的时间。
//        //        如果使用绝对过期，则 slidingExpiration 参数必须为 Cache.NoSlidingExpiration。
//        //
//        //   slidingExpiration:
//        //     最后一次访问所插入对象时与该对象过期时之间的时间间隔。如果该值等效于 20 分钟，
//        //       则对象在最后一次被访问 20 分钟之后将过期并被从缓存中移除。如果使用可调过期，则
//        //     absoluteExpiration 参数必须为 System.Web.Caching.Cache.NoAbsoluteExpiration。
//        //
//        //   priority:
//        //     该对象相对于缓存中存储的其他项的成本，由 System.Web.Caching.CacheItemPriority 枚举表示。
//        //       该值由缓存在退出对象时使用；具有较低成本的对象在具有较高成本的对象之前被从缓存移除。
//        //
//        //   onRemoveCallback:
//        //     在从缓存中移除对象时将调用的委托（如果提供）。
//        //            当从缓存中删除应用程序的对象时，可使用它来通知应用程序。
//        //
//        // 异常:
//        //   System.ArgumentException:
//        //     为要添加到 Cache 中的项设置 absoluteExpiration 和 slidingExpiration 参数。
//        //
//        //   System.ArgumentNullException:
//        //     key 或 value 参数为 null。
//        //
//        //   System.ArgumentOutOfRangeException:
//        //     将 slidingExpiration 参数设置为小于 TimeSpan.Zero 或大于一年的等效值。
//        public void Insert(string key, object value, CacheDependency dependencies,
//                            DateTime absoluteExpiration, TimeSpan slidingExpiration,
//                            CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback);

//        // 从应用程序的 System.Web.Caching.Cache 对象移除指定项。
//        public object Remove(string key);

//        // 将对象与依赖项策略、到期策略和优先级策略
//        // 以及可用来在从缓存中移除项【之前】通知应用程序的委托一起插入到 Cache 对象中。
//        // 注意：此方法受以下版本支持：3.5 SP1、3.0 SP1、2.0 SP1
//        public void Insert(string key, object value, CacheDependency dependencies,
//                                DateTime absoluteExpiration, TimeSpan slidingExpiration,
//                                CacheItemUpdateCallback onUpdateCallback);
//    }
//}

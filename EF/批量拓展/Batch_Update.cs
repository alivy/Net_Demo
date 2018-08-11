using EF.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.批量拓展
{
     
    public  class Batch_Update
    {

        private static IEnumerable<User_info> GetInsertDatas()
        {
            // 线程安全的list
            ConcurrentBag<User_info> datas = new ConcurrentBag<User_info>();
            Parallel.For(0, 100000,(index, state) =>
                    {
                        Random rand = new Random();
                        var newData = new User_info { User_Name = rand.Next(1, 100).ToString() ,User_Pwd ="密码"+index};
                        datas.Add(newData);
                    });

            return datas;
        }

        /// <summary>
        ///     批量插入
        /// </summary>
        //private static void BatchInster()
        //{
          
        //    var datas = GetInsertDatas();
        //    var testEntities = datas as IList<User_info> ?? datas.ToList();

        //    Stopwatch watch =new Stopwatch();
            
        //    Console.WriteLine("开始插入计时,总共数据:{0}条",testEntities.Count());
        //    watch.Start();

        //    using (var context = DBContext.CreateContext())
        //    {
        //        EFBatchOperation.For(context,context.TestEntities)
        //            .InsertAll(testEntities);
        //    }

        //    watch.Stop();
        //    Console.WriteLine("结束插入计时,工用时:{0}ms",watch.ElapsedMilliseconds);


        //    using (var context = new BatchDemoContext())
        //    {
        //        var count = context.TestEntities.Count();
        //        Console.WriteLine("数据库总共数据:{0}条",count);

        //        var minId = context.TestEntities.Min(c => c.Id);

        //        // 随机取十条数据进行验证

        //        for (int i = 1; i <= 10; i++)
        //        {
        //            Random rand = new Random();
        //            var id = rand.Next(minId, minId+ 100000);
                    
        //            var testdata = context.TestEntities.FirstOrDefault(c => c.Id == id);
                    
        //            Console.WriteLine("插入的数据 id:{0} randomvalue:{1}",testdata.Id,testdata.RandomVlue);

        //        }
                
        //    }

        //    Console.WriteLine("-----------------华丽的分割线   插入-------------------------");
        //}


    }
}

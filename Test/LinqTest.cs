using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class LinqTest
    {
        public List<models> listModel;

        [TestInitialize]
        public void Initialization()
        {
            var model1s = new List<model1>();
            model1s.Add(new model1() { id = 10, code = 15 });
            model1s.Add(new model1() { id = 10, code = 15 });
            model1s.Add(new model1() { id = 10, code = 15 });
            model1s.Add(new model1() { id = 10, code = 15 });

            listModel = new List<models>();
            listModel.Add(new models() { id = 10, Name = "Lucy", Phone = "13545147370", code = 15, model1s = model1s });
            listModel.Add(new models() { id = 10, Name = "Lucy", Phone = "13545147370", code = 15, model1s = model1s });
            listModel.Add(new models() { id = 10, Name = "Lucy", Phone = "13545147370", code = 15, model1s = model1s });
            listModel.Add(new models() { id = 10, Name = "Lucy", Phone = "13545147371", code = 15 });
            listModel.Add(new models() { id = 10, Name = "Lucy", Phone = "13545147372", code = 15 });
            listModel.Add(new models() { id = 13, Name = "Lucy1", Phone = "13545147370", code = 15 });
            listModel.Add(new models() { id = 14, Name = "Lucy2", Phone = "13545147370", code = 15 });
            //list.Add(new models() { id = 29, Name = "Jack", Phone = "13867671212" });
            //list.Add(new models() { id = 19, Name = "bobo", Phone = "13987872323" });
            //list.Add(new models() { id = 15, Name = "hk", Phone = "13527271818" });
            //list.Add(new models() { id = 33, Name = "cy", Phone = "15627271616" });

        }

        [TestMethod]
        public void TestGroupBy()
        {
            var td = new List<double[]>();
            var t1 = new double[] { 1, 2, 3, 4, 5 };
            var t2 = new double[] { 6, 7, 8, 9, 10 };
            td.Add(t1);
            td.Add(t2);
            string  json = JsonHelper.Serialize(td);
            //分组查询多列和
            var aa = listModel.GroupBy(x => new
            {
                x.id,
                x.code,
                x.Name,
                x.Phone
            }).Select(t => new Double[]
            {
               t.Sum(x => x.id),
               t.Sum(x => x.code)
            }).ToArray();

            //匿名函数求和
            var bb = listModel.GroupBy(x => new { x.Name, x.id }).Sum(t => t.Key.id);


            var cc = listModel.GroupBy(x => new { x.Name, x.id })
                .Select(x => new
                {
                    x.Key.id,
                    x.Key.Name,
                    Phone = listModel.Where(t => t.id == x.Key.id).Select(t => t.Phone).ToArray()
                }).ToList();



            //分组查询
            var tt = listModel.GroupBy(x => new models
            {
                id = 1,
                Name = x.Name,
                Phone = x.Phone
            }).ToList();

            var i = 1;
            //加排序编号
            var ss = listModel
                    .OrderBy(p => p.Name)
                    .OrderByDescending(p => p.id)
                    .Select((p, idx) => new
                    {
                        row = idx,
                        name = p.Name,
                        phone = p.Phone
                    }).ToList();
        }

        [TestMethod]
        public void TestQuery()
        {
            var a = listModel.Select(x => new { model1 = x.model1s ?? new List<model1>() }).ToList();

            var b = a.GroupBy(x => new { model1 = x.model1 }).Select(x => x.Key.model1).ToList();
        }
    }

    public class models
    {
        public int id { set; get; }
        public int code { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime Birthday { set; get; }

        public static int idx { set; get; }


        public List<model1> model1s { set; get; }
        //public static int Idx
        //{
        //    get { return models.idx; }
        //    set { models.idx = 0; }
        //}
        //public models()
        //{
        //    //id = Idx++;
        //    Name = "Name" + id.ToString();
        //    Phone = "Phone" + id.ToString();
        //    Address = "Address" + id.ToString();
        //    Birthday = DateTime.Now.AddHours(id);
        //}

    }

    public class model1
    {
        public int id { set; get; }
        public int code { set; get; }
    }
}

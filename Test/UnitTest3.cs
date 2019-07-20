using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {

            List<ExamScore> a1 = new List<ExamScore>();
            a1.Add(new ExamScore { Code = 1, Num = 1, Socre = 50 });
            a1.Add(new ExamScore { Code = 1, Num = 2, Socre = 100 });


            List<ExamScore> a2 = new List<ExamScore>();
            a2.Add(new ExamScore { Code = 2, Num = 1, Socre = 40 });
            a2.Add(new ExamScore { Code = 2, Num = 2, Socre = 60 });
            List<ExamScore> a4 = a1.Union(a2).ToList();



            List<ExamScore> a3 = new List<ExamScore>();
            var a1SumScore = a1.Sum(x => x.Socre);
            var a2SumScore = a2.Sum(x => x.Socre);
            var maxScore = Math.Max(a1SumScore, a2SumScore);
            var sumSocre = a1SumScore + a2SumScore;



            for (int i = 0; i < a4.Count; i++)
            {
                var ae = new ExamScore();
                ae.Num = i;
                if (a4[i].Code == 1)
                {

                    var t1 = a1SumScore / sumSocre; //得到试卷分数据占比
                    var t2 = t1 * maxScore;         //得到试卷分数
                    var t3 = t2 / a1SumScore;       //得到本试卷在组合后试卷比例
                    var score = a4[i].Socre * t3;

                    ae.Socre = a4[i].Socre * maxScore * a1SumScore / sumSocre / a1SumScore;
                }
                else
                {
                    ae.Socre = a4[i].Socre * maxScore / sumSocre;
                }
                a3.Add(ae);
            }
            var a3SunSocre = a3.Sum(x => x.Socre);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string date = string.Format("{0:yyyy 年 MM 月 dd}-{1:yyyy 年 MM 月 dd}", DateTime.Now, DateTime.Now);
            var s =  Convert.ToInt32(1==1);
            var dic = new Dictionary<int, List<int>>();
            var list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            var list2 = new List<int>();
            list1.Add(4);
            list1.Add(5);
            list1.Add(6);
            dic.Add(1, list1);
            dic[1].AddRange(list2);
          
           
            var num = dic.Count();
        }

    }

    public class ExamScore
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 题号
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Socre { get; set; }
    }
}

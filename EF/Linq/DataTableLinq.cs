using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Linq
{
    class DataTableLinq
    {
        DataTable dtHead = new DataTable();
        DataTable dtTail = new DataTable();
        DataTable DtAll = new DataTable();

      

        /// <summary>
        /// 创建表结构，添加数据源
        /// </summary>
        private void AddData()
        {
            dtHead.Columns.Add("GoodID", typeof(Int32));
            dtHead.Columns.Add("GoodName", typeof(String));

            dtTail.Columns.Add("GoodID", typeof(Int32));
            dtTail.Columns.Add("Num", typeof(Int32));
            dtTail.Columns.Add("Money", typeof(Int32));

            DtAll.Columns.Add("GoodID", typeof(Int32));
            DtAll.Columns.Add("GoodName", typeof(String));
            DtAll.Columns.Add("Num", typeof(Int32));
            DtAll.Columns.Add("Money", typeof(Int32));

            this.AddRow(1, "青岛纯生", 10, 30);
            this.AddRow(2, "哈尔滨啤酒", 5, 20);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="goodID"></param>
        /// <param name="goodName"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        private void AddRow(Int32 goodID, String goodName, Int32 num1, Int32 num2)
        {
            DataRow drH = dtHead.NewRow();
            drH["GoodID"] = goodID;
            drH["GoodName"] = goodName;
            dtHead.Rows.Add(drH);

            DataRow drT = dtTail.NewRow();
            drT["GoodID"] = goodID;
            drT["Num"] = num1;
            drT["Money"] = num2;
            dtTail.Rows.Add(drT);
        }

        /// <summary>
        /// “连接”按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Join_Click()
        {
            //方案一
            var query1 =
                from rHead in dtHead.AsEnumerable()
                from rTail in dtTail.AsEnumerable()
                where rHead.Field<Int32>("GoodID") == rTail.Field<Int32>("GoodID")
                select new
                {
                    GoodID = rHead.Field<Int32>("GoodID"),
                    GoodName = rHead.Field<String>("GoodName"),
                    Num = rTail.Field<Int32>("Num"),
                    Money = rTail.Field<Int32>("Money")
                };
           
            DataTable dtNew = DtAll.Copy();
            foreach (var obj in query1)
            {
                dtNew.Rows.Add(obj.GoodID, obj.GoodName, obj.Num, obj.Money);
            }

            //方案二
            var query =
                from rHead in dtHead.AsEnumerable()
                join rTail in dtTail.AsEnumerable()
                on rHead.Field<Int32>("GoodID") equals rTail.Field<Int32>("GoodID")
                select rHead.ItemArray.Concat(rTail.ItemArray.Skip(1));

            foreach (var obj in query)
            {
                DataRow dr = DtAll.NewRow();
                dr.ItemArray = obj.ToArray();
                DtAll.Rows.Add(dr);
            }
        }
    }
}



    
       
           
    


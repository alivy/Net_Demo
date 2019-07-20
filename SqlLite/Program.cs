using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "SELECT userId,userName,userPwd,Starts FROM UserInfo";
            string path = System.IO.Directory.GetCurrentDirectory();

            //string conStr = "D:/sqlliteDb/document.db";
            string connStr = @"Data Source=" +path + @"\CarryTrain.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
            connStr = "Data Source=C:\\Users\\Administrator\\source\\repos\\CarryTrainService\\Tool.Test\\bin\\Debug\\CarryTrain.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
           
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //conn.Open();
                using (SQLiteDataAdapter ap = new SQLiteDataAdapter(sql, conn))
                {
                    DataSet ds = new DataSet();
                    ap.Fill(ds);
                    DataTable dt = ds.Tables[0];
                }
            }
        }
    }
}

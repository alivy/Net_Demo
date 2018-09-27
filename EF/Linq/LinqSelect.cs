using EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Linq
{
 
    public class LinqSelect
    {
        public static DBContext db = DBContext.CreateContext();
        /// <summary>
        /// 后台多表查询  内连接
        /// </summary>
        public void INNER_JOIN()
        {

            var str = new string[] {"更新用户名0","更新用户名1","更新用户名2","更新用户名3","更新用户名4","更新用户名5","更新用户名7"};
            var UserNameList = db.User_info.Where(x => str.Contains(x.User_Name)).ToList();
            //var abc = db.User_info.SqlQuery("SELECT *   FROM User_info").ToList();
            //string sql = "SELECT User_Name as Name  FROM User_info";
            //var Tables = db.Database.SqlQuery<dynamic>(sql).ToList();
            //Tables.ForEach(a => Console.WriteLine(String.Format("姓名：{0} ,密码 {1},用户类型名称 {2},", a.Name, a.Name, a.Name)));
            var userListTest = (from u in db.User_info
                                join p in db.User_Type on u.User_Type equals p.UserType_ID 
                                join c in db.QQUser_info on u.Id equals c.ID
                                where !string.IsNullOrEmpty(p.Remark) &
                                p.UserType_ID ==u.User_Type
                                select new { u.User_Name, u.User_Pwd, p.UserType_Name }).ToList();


           
            List<dynamic> oneList = new List<dynamic>();  
            foreach (var one in userListTest)
            {
                dynamic dyObject = new ExpandoObject();
                dyObject.userName = one.User_Name;
                dyObject.userPwd = one.User_Pwd;
                dyObject.userTypeName = one.UserType_Name;
                oneList.Add(dyObject);
            }
            //userListTest.Select(m =>  new ExpandoObject
            //{
            //    userName = m.User_Name,
            //    userPwd = m.User_Pwd,
            //    userTypeName = m.UserType_Name,
            //});

            oneList.ForEach(a => Console.WriteLine(String.Format("姓名：{0} ,密码 {1},用户类型名称 {2},", a.userName, a.userPwd, a.userTypeName)));
           
        }
        /// <summary>
        /// 多表联查 外链接：LEFT OUTER JOIN
        /// </summary>
        public void LEFT_OUTER_JOIN() {
      
            var userListTest = (from u in db.User_info
                                join p in db.User_Type on u.User_Type equals p.UserType_ID  into temp from t in temp.DefaultIfEmpty()
                                where !string.IsNullOrEmpty(t.Remark)
                                //join d in db.partBs on t.partID equals d.partID
                                //into tempone
                                //from user in tempone.DefaultIfEmpty()
                                select new { u.User_Name, u.User_Pwd, t.UserType_Name }).ToList();
            DbRawSqlQuery ss = db.Database.SqlQuery(typeof(User_info), "");
            DbRawSqlQuery<User_info> ss1 = db.Database.SqlQuery<User_info>("");

            var abc = db.User_info.SqlQuery("").ToList();

            List<dynamic> oneList = new List<dynamic>();
            foreach (var one in userListTest)
            {
                dynamic dyObject = new ExpandoObject();
                dyObject.userName = one.User_Name;
                dyObject.userPwd = one.User_Pwd;
                dyObject.userTypeName = one.UserType_Name;
                oneList.Add(dyObject);
            }
            oneList.ForEach(a => Console.WriteLine(String.Format("姓名：{0} ,密码 {1},用户类型名称 {2},", a.userName, a.userPwd, a.userTypeName)));
        }

     
    }
}

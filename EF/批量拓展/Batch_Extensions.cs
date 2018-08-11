using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;
using EntityFramework.Extensions;
using System.Linq.Expressions;

namespace EF
{
	public class Batch_Extensions
	{
		/// <summary>
		/// 批量更新
		/// </summary>
		/// <returns>更新条目</returns>
		public int Update()
		{
			using (var db = DBContext.CreateContext())
			{



                return db.User_info.Where(u => u.User_Name.EndsWith("张三")).Update(u => new User_info { Remark = u.User_Name + "批量更新" });
            }
		}




    



        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns>删除条目</returns>
        public int Delete()
		{

			using (var db = new EF.Model.CodeFrist.CodeFrist())
			{
			}

			using (var db = DBContext.CreateContext())
			{
				return db.User_info.Where(u => u.Remark.EndsWith("batch_Remark86号")).Delete();
			}
		}

		/// <summary>
		/// 批量插入
		/// </summary>
		/// <returns>批量插入</returns>
		public bool Insert()
		{
			List<User_info> infos = new List<User_info>();
			for (int i = 0; i < 1000; i++)
			{
				User_info user = new User_info
				{
					UserID = "batch" + i.ToString(),
					User_Name = "batch张三" + i.ToString() + "号",
					User_Pwd = "batch_Pwd" + i.ToString() + "号",
					User_Type = i,
					Remark = "batch_Remark" + i.ToString() + "号"
				};
				infos.Add(user);
			}
			return infos.Where(x=>x.User_Type <100).ToList().BulkInsert<User_info>("User_info");
		}
	}
}

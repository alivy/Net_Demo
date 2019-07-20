using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conver
{
    public class Class1
    {

        public DataTable GetTable()
        {

            int[] id = { 4, 5, 1, 3, 2, 7, 6 };
            string[] name = { "Tom", "Jack", "HelloWorld", "Visual Studio", "Gril", "Timmy", "Geo" };
            DataTable table = new DataTable("Student");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            for (int i = 0; i < id.Length; i++)
            {
                table.Rows.Add(new object[] { id[i], name[i] });
            }
            var result = table.AsEnumerable().Where(x => x.Field<int>("ID") == 4);
            return table;

        }
    }
}

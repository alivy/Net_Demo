using EF;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelForm.Generator
{
    public class GenTables
    {
        public static DBContext db = DBContext.CreateContext();

        public static List<Table> GetTables(string dbType)
        {
            var gen = GetGenProvider(dbType);
            //var provider = GetProvider(dbType);
            
            using (var db =  DBContext.CreateContext())
            {

                var Tables = db.Database.SqlQuery<Table>(gen.SqlGetTableNames()).ToList();

                foreach (var T in Tables)
                {
                    T.TableKeys = db.Database.SqlQuery<Table>(gen.SqlGetTableKeys(T.TableName)).Select(x => x.TableName).ToList<string>();
                    T.TableSchemas = db.Database.SqlQuery<TableSchema>(gen.SqlGetTableSchemas(T.TableName)).ToList();
                }
                return Tables;
            }
        }


        //public static List<Table> GetTables(string dbType, string conString)
        //{
        //    var gen = GetGenProvider(dbType);
        //    var provider = GetProvider(dbType);

        //    using (var db = new DbContext().ConnectionString(conString, provider))
        //    {
        //        var Tables = db.Sql(gen.SqlGetTableNames()).QueryMany<Table>();

        //        foreach (var T in Tables)
        //        {
        //            T.TableKeys = db.Sql(gen.SqlGetTableKeys(T.TableName)).QueryMany<TableKey>().Select<TableKey, string>(x => x.column_name).ToList<string>();
        //            T.TableSchemas = db.Sql(gen.SqlGetTableSchemas(T.TableName)).QueryMany<TableSchema>();
        //        }
        //        return Tables;
        //    }
        //}

        public static ISqlGen GetGenProvider(string type)
        {
            switch (type)
            {
                case "Oracle":
                    return new OracleGen();

                case "SqlServer":
                default:
                    return new SqlServerGen();
            }
        }


        //private static IDbProvider GetProvider(string type)
        //{
        //    switch (type)
        //    {
        //        case "Oracle":
        //            return new OracleProvider();

        //        case "SqlServer":
        //        default:
        //            return new SqlServerProvider();
        //    }
        //}
    }
}

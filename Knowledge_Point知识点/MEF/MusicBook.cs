using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Point知识点.MEF
{
    //Export出去的类型和名称都要和Import标注的属性匹配，类型可以写IBookService, 也可以写MusicBook  
    [Export(typeof(IBookService))]
    public class MusicBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MusicBook";
        }
    }


    [Export("GreenBook", typeof(IBookService))]
    public class GreenBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "ColorBook ";
        }
    }


    [Export("MusicBook", typeof(IBookService))]
    public class MathBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MathBook ";
        }
    }
    /// <summary>
    /// Export指定MusicBook契约名,在导入(Import)使用是object类型，需要强转
    /// </summary>
    [Export("MusicBook")]
    public class MathBook_Backups : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "MathBook_Backups ";
        }
    }

    /// <summary>
    /// Export指定MusicBook契约名,导入(Import)时就要指定的契约名
    /// </summary>
    [Export("MusicBook", typeof(IBookService))]
    public class HistoryBook : IBookService
    {
        public string BookName { get; set; }

        public string GetBookName()
        {
            return "HistoryBook";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Point知识点.MEF
{
    public  interface IBookService
    {
        string BookName { get; set; }
        string GetBookName();
    }
}

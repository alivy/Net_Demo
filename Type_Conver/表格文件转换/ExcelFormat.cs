using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conver
{
    public class ExcelFormat
    {
        public void ToExcel(string physicalPath)
        {
            //string physicalPatha = "~/UploadFiles/Part/";
            //physicalPatha += phyPath;
            //string physicalPath = Server.MapPath(Server.UrlDecode(physicalPatha));
            //string u = "UploadFiles/Part/";
            //u += phyPath;
            //string url = physicalPatha;
            Microsoft.Office.Interop.Excel.Application application = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            application = new Microsoft.Office.Interop.Excel.Application();
            object missing = Type.Missing;
            object trueObject = true;
            application.Visible = false;
            application.DisplayAlerts = false;
            workbook = application.Workbooks.Open(physicalPath, missing, trueObject, missing, missing, missing,
              missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //Save Excelto Html  
            object format = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
            string htmlName = Path.GetFileNameWithoutExtension(physicalPath) + ".html";
            String outputFile = Path.GetDirectoryName(physicalPath) + "\\" + htmlName;
            workbook.SaveAs(outputFile, format, missing, missing, missing,
                             missing, XlSaveAsAccessMode.xlNoChange, missing,
                              missing, missing, missing, missing);
            workbook.Close();
            application.Quit();
        }
        
    }
}

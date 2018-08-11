using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Type_Conver
{
    public class WordFormat
    {
        public void PreviewWord(string physicalPath)
        {
            Microsoft.Office.Interop.Word._Application application = null;
            Microsoft.Office.Interop.Word._Document doc = null;
            application = new Microsoft.Office.Interop.Word.Application();
            object missing = Type.Missing;
            object trueObject = true;
            application.Visible = false;
            application.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            doc = application.Documents.Open(physicalPath, missing, trueObject, missing, missing, missing,
              missing, missing, missing, missing, missing, missing, missing, missing, missing);
            //Save Excelto Html  
            object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;
            string htmlName = Path.GetFileNameWithoutExtension(physicalPath) + ".html";
            String outputFile = Path.GetDirectoryName(physicalPath) + "\\" + htmlName;
            doc.SaveAs(outputFile, format, missing, missing, missing,
                               missing, XlSaveAsAccessMode.xlNoChange, missing,
                                missing, missing, missing, missing);
            doc.Close();
            application.Quit();
        }
    }
}

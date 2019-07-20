using Aspose.Words;
using Aspose.Words.Tables;
using RuanYun.Word;
using RuanYun.Word.Builder.GridData;
using System.Collections.Generic;
using System.Drawing;
using CellMerge = RuanYun.Word.Builder.GridData.CellMerge;

namespace Utils工具.ASPOSE
{
    /// <summary>
    /// 
    /// </summary>
    public class KnowledgePointIncreasementTableToken
    {

        private string imgCodePath = "D:\\temp\\imgCode.png";
        public void CreateTable()
        {
            string tempFile = "D:\\temp\\IncreaseStrategy.docx";
            Document doc = new Document(tempFile);
            var builder = new DocumentBuilder(doc);
            var document = WordFactory.CreateBuilder(tempFile);

            string str = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                string from = "{KnowledgePointIncreasementTable" + i + "} \n\n";
                str += from;
            }
            document.ReplaceCallBack("{KnowledgePointIncreasementTable}", writer => writer.WritelnText(str, 12));

            //合并单元格cells.Merge(1, 0, 3, 1) 参数1代表当前行，参数0代表当前行当前列即第一行第一列，参数3合并的行数，参数4合并的列数  
            //document.ReplaceCallBack("{KnowledgePointIncreasementTable}", writer => writer.WriteGridTable(GetTable(), true, GetCellMerges().ToArray()));


            document.ReplaceCallBack("{KnowledgePointIncreasementTable1}", writer => writer.WriteGridTable(GetTable(), false, GetCellMerges().ToArray()));
            document.ReplaceCallBack("{KnowledgePointIncreasementTable2}", writer => writer.WriteGridTable(GetTable(), false, GetCellMerges().ToArray()));
            document.ReplaceCallBack("{KnowledgePointIncreasementTable3}", writer => writer.WriteGridTable(GetTable(), false, GetCellMerges().ToArray()));
            document.ReplaceCallBack("{KnowledgePointIncreasementTable4}", writer => writer.WriteGridTable(GetTable(), false, GetCellMerges().ToArray()));
            document.ReplaceCallBack("{KnowledgePointIncreasementTable0}", writer => writer.WriteGridTable(GetTable(), false, GetCellMerges().ToArray()));

            



            document.Save("D:\\temp\\IncreaseStrategyResult.docx");
        }

        private void CreateTableHeader(GridTable tb)
        {
            var hr = tb.NewRow();
            hr.DefaultBorder = true;
            hr[0].Text = "学科";
            hr[1].Text = "高考预测";
            hr[2].Text = "冲刺提分";
            hr.DefaultBackgroundColor = Color.FromArgb(68, 154, 201);
            hr.DefaultForegroundColor = Color.White;
            hr.DefaultFontSize = 12;
            hr.RowHeight = 32;
            hr.DefaultCellAlign = CellAlign.Center;
            tb.AddRow(hr);
        }

        /// <summary>
        /// 构造列
        /// </summary>
        /// <returns></returns>
        public List<CellMerge> GetCellMerges()
        {
            var cellMerges = new List<CellMerge>();
            cellMerges.Add(new CellMerge(0, 1, 0, 2));
            cellMerges.Add(new CellMerge(1, 1, 1, 2));
            cellMerges.Add(new CellMerge(2, 1, 2, 2));
            cellMerges.Add(new CellMerge(3, 1, 3, 2));
            return cellMerges;
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <returns></returns>
        public GridTable GetTable()
        {
            var tb = new GridTable(3)
            {
                DefaultColWidth = new double[] { 150, 320, 80 },
                TablePreferredWidth = PreferredWidth.FromPercent(100),
                DefaultFontName = "微软雅黑",
                DefaultFontNameAscii = "Microsoft YaHei",
                DefaultFontSize = 12,
                DefaultForegroundColor = GetRgb("#333"),
                DefaultCellAlign = CellAlign.Center,
                DefaultBorderColor = Color.LightGray,
            };
            KnowledgePoints(tb);
            MasteryLevel(tb);
            ImprovementRoom(tb);
            MajorKnowledgePoints(tb);
            KnowledgePointMicroCourse(tb);
            return tb;
        }
        /// <summary>
        /// 知识点列
        /// </summary>
        private void KnowledgePoints(GridTable tb)
        {
            var knowledgePoints = tb.NewRow();
            knowledgePoints[0].Html = string.Format("<img src = '{0}' style = 'width:15; height:15;' /> <span style='font-size:16;font-weight:bold;font-family:微软雅黑'>{1}</span>", imgCodePath, "知识点");
            knowledgePoints[1].Text = "测试知识点描述";
            knowledgePoints[2].Text = "";
            SetTableStyle(knowledgePoints, true);
            tb.AddRow(knowledgePoints);
        }

        /// <summary>
        /// 掌握水平列
        /// </summary>
        /// <param name="tb"></param>
        private void MasteryLevel(GridTable tb)
        {
            var masteryLevel = tb.NewRow();
            masteryLevel[0].Html = string.Format("<img src = '{0}' style = 'width:15; height:15;' /> <span style='font-size:16;font-weight:bold;font-family:微软雅黑'>{1}</span>", imgCodePath, "掌握水平");
            masteryLevel[1].Text = "测试掌握水平描述";
            masteryLevel[2].Text = "";
            SetTableStyle(masteryLevel);
            tb.AddRow(masteryLevel);
        }

        /// <summary>
        /// 提升空间
        /// </summary>
        /// <param name="tb"></param>
        private void ImprovementRoom(GridTable tb)
        {
            var improvementRoom = tb.NewRow();
            improvementRoom[0].Html = string.Format("<img src = '{0}' style = 'width:15; height:15;' /> <span style='font-size:16;font-weight:bold;font-family:微软雅黑'>{1}</span>", imgCodePath, "提升空间");
            improvementRoom[1].Text = "测试提升空间描述";
            improvementRoom[2].Text = "";
            SetTableStyle(improvementRoom);
            tb.AddRow(improvementRoom);
        }


        private void MajorKnowledgePoints(GridTable tb)
        {
            var majorKnowledgePoints = tb.NewRow();
            majorKnowledgePoints[0].Html = string.Format("<img src = '{0}' style = 'width:15; height:15;' /> <span style='font-size:16;font-weight:bold;font-family:微软雅黑';>{1}</span>", imgCodePath, "主要攻破知识点");
            majorKnowledgePoints[1].Text = "测试主要攻破知识点描述";
            majorKnowledgePoints[2].Text = "";
            SetTableStyle(majorKnowledgePoints);
            tb.AddRow(majorKnowledgePoints);
        }

        /// <summary>
        /// 知识点微课
        /// </summary>
        /// <param name="tb"></param>
        private void KnowledgePointMicroCourse(GridTable tb)
        {
            var knowledgePointMicroCourse = tb.NewRow();
            string describe = "测试主要攻破知识点描述";
            knowledgePointMicroCourse[0].Html = string.Format("<img src = '{0}' style = 'width:15; height:15;' /> <span style='font-size:16;font-weight:bold;font-family:微软雅黑'>{1}</span>", imgCodePath, "知识点微课");
            knowledgePointMicroCourse[1].Text = describe;
            knowledgePointMicroCourse[2].Html = string.Format(@"<img src='{0}' style='width:2cm; height:2cm;'/>", imgCodePath);
            //knowledgePointMicroCourse[1].TopPadding = 0;
            //knowledgePointMicroCourse[1].Html = string.Format(@"<span style='margin: 0px; padding: 0px;font-family:Microsoft YaHei;float:left'>{0}</span>
            //                                                    <img src='{1}' style='width:2cm; height:2cm;'/>", describe, imgCodePath);
            SetTableStyle(knowledgePointMicroCourse);
            knowledgePointMicroCourse[1].CellAlign = CellAlign.Right;
            knowledgePointMicroCourse[1].RightBorderSetting.Color = Color.White;


            knowledgePointMicroCourse[2].CellAlign = CellAlign.Right;
            knowledgePointMicroCourse[2].RightPadding = 7;
            knowledgePointMicroCourse[2].TopPadding = 5;
            knowledgePointMicroCourse[2].BottomPadding = 5;
            knowledgePointMicroCourse[2].Border = true;
            knowledgePointMicroCourse[2].LeftBorderSetting.Color = Color.White;
            tb.AddRow(knowledgePointMicroCourse);
        }

        /// <summary>
        /// 设置表格样式
        /// </summary>
        /// <param name="row"></param>
        /// <param name="head"></param>
        public void SetTableStyle(GridRow row, bool head = false)
        {

            row[0].Border = true;
            row[0].ForegroundColor = Color.Black;
            row[0].LeftPadding = 2;
            row[0].FontSize = 12;

            row[1].FontSize = 10.5;
            row[1].LeftPadding = 20;
            row[1].Border = head;

            row.DefaultBackgroundColor = head ? GetRgb("#EEEEEE") : Color.White;
            row.RowHeight = 25;
            row.DefaultCellAlign = CellAlign.Left;
        }

        /// <summary>
        /// 根据16进制色值获取rgb的色值
        /// </summary>
        /// <param name="hex">16进制色值</param>
        /// <returns></returns>
        public static Color GetRgb(string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }
    }
}

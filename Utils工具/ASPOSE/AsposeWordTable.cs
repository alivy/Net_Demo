
using Aspose.Words;
using Aspose.Words.Tables;
using RuanYun.Word;
using RuanYun.Word.Builder;
using RuanYun.Word.Builder.GridData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils工具.ASPOSE
{

    /// <summary>
    /// .net 生成相关图表帮助类
    /// </summary>

    public class AsposeWordTable
    {
        public void AsposeWordTable1()
        {
            string tempFile = "D:\\test.docx";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            // var writer = new WordWriter(builder);
            var document = WordFactory.CreateBuilder(tempFile);
            document.ReplaceCallBack("{SubjectTable}", writer =>
            {
                var tb = new GridTable(3) { DefaultColWidth = new double[] { 60, 60, 60 } };
                ChartHelper.TableCommonSetting(tb);
                CreateTableHeader(tb);
                CreateExamStatisticRow(tb);
                writer.WriteGridTable(tb);
            });
            document.Save("D:\\test.docx");
        }




        /// <summary>
        /// 创建表格头部内容
        /// </summary>
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
            hr.RowHeight = 25;
            hr.DefaultCellAlign = CellAlign.Center;
            tb.AddRow(hr);
        }

        /// <summary>
        /// 增加各科成绩预测内容行
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="entity"></param>
        private void CreateExamStatisticRow(GridTable tb)
        {
            var entity = CreateEntityTable();
            for (int i = 0; i < entity.Count; i++)
            {
                var tr = tb.NewRow();
                tr[0].Text = entity[i].CourseShortName;
                tr[1].Text = entity[i].PredictionScoreDisplay;
                tr[2].Text = entity[i].PointsToGainDisplay;
                tr.DefaultBackgroundColor = i % 2 == 0 ? Color.FromArgb(219, 228, 233) : Color.White;
                tr.DefaultForegroundColor = Color.FromArgb(107, 109, 111);
                tr.DefaultFontSize = 10;
                tr.RowHeight = 32;
                tr.DefaultCellAlign = CellAlign.Center;
                tb.AddRow(tr);
            }
        }

        private List<EntityTable> CreateEntityTable()
        {
            List<EntityTable> entityTables = new List<EntityTable>();
            for (int i = 0; i < 6; i++)
            {
                EntityTable entityTable = new EntityTable();
                entityTable.CourseShortName = "语文";
                entityTable.PredictionScoreDisplay = "100";
                entityTable.PointsToGainDisplay = "9";
                entityTables.Add(entityTable);
            }
            return entityTables;
        }



    }

    public class EntityTable
    {
        public string CourseShortName { get; set; }
        public string PredictionScoreDisplay { get; set; }
        public string PointsToGainDisplay { get; set; }
    }

}

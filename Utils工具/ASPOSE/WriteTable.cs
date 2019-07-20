using Aspose.Words;
using Aspose.Words.Tables;
using RuanYun.Word;
using RuanYun.Word.Builder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.ASPOSE
{
    /// <summary>
    /// 画表格
    /// </summary>
    public class WriteTable
    {
        private string imgCodePath = "D:\\temp\\imgCode1.jpg";
        public void CreateTable()
        {
            string tempFile = "D:\\temp\\IncreaseStrategy.docx";
            Document doc = new Document(tempFile);
            var builder = new DocumentBuilder(doc);
            var document = WordFactory.CreateBuilder(tempFile);
            string str = "{KnowledgePointIncreasementTable}";
            document.ReplaceCallBack(str, writer => PaintingTable(writer));
            document.Save("D:\\temp\\IncreaseStrategyResult.docx");
        }

        //public List<CellMerge> GetCellMerges()
        //{
        //    var cellMerges = new List<CellMerge>();
        //    cellMerges.Add(new CellMerge(0, 1, 0, 2));
        //    cellMerges.Add(new CellMerge(1, 1, 1, 2));
        //    cellMerges.Add(new CellMerge(2, 1, 2, 2));
        //    cellMerges.Add(new CellMerge(3, 1, 3, 2));
        //    return cellMerges;
        //}

        /// <summary>
        /// 画表格
        /// </summary>
        public void PaintingTable(WordWriter writer)
        {

            var tableWidth = GetTableWidth(writer);
            var builder = writer.DocumentBuilder;
            for (int i = 0; i < 3; i++)
            {
                var table = builder.StartTable();
                InitTableStyle(builder);
                KnowledgePoints(builder, tableWidth);
                MasteryLevel(builder);
                ImprovementRoom(builder);
                MajorKnowledgePoints(builder);
                KnowledgePointMicroCourse(builder);
                builder.EndTable();
                builder.Write("\n");
            }
        }

        /// <summary>
        /// 知识点列
        /// </summary>
        private void KnowledgePoints(DocumentBuilder builder, double tableWidth)
        {
            LeftTitleStyle(builder);
            builder.CellFormat.Shading.BackgroundPatternColor = ColorTranslator.FromHtml("#EEEEEE");
            builder.Write("知识点一");

            RightContentStyle(builder);
            builder.Bold = true;
            builder.CellFormat.Shading.BackgroundPatternColor = ColorTranslator.FromHtml("#EEEEEE");
            builder.Write("有理数");
            builder.EndRow();
        }

        /// <summary>
        /// 掌握水平列
        /// </summary>
        /// <param name="tb"></param>
        private void MasteryLevel(DocumentBuilder builder)
        {
           
            LeftTitleStyle(builder);
            builder.Write("掌握水平");


            RightContentStyle(builder);
            builder.Write("目前水平84% → 将达到水平98%");
            builder.EndRow();
        }


        /// <summary>
        /// 提升空间
        /// </summary>
        /// <param name="tb"></param>
        private void ImprovementRoom(DocumentBuilder builder)
        {
           
            LeftTitleStyle(builder);
            builder.Write("提升空间");



            RightContentStyle(builder);
            builder.Write("7~10");
            builder.EndRow();
        }


        private void MajorKnowledgePoints(DocumentBuilder builder)
        {
           
            LeftTitleStyle(builder);
            builder.Write("主要攻破知识点");
            builder.CellFormat.Width = 150;


            RightContentStyle(builder);
            builder.Write("测试主要攻破知识点描述");
            builder.EndRow();
        }

        /// <summary>
        /// 知识点微课
        /// </summary>
        /// <param name="tb"></param>
        private void KnowledgePointMicroCourse(DocumentBuilder builder)
        {
          
            LeftTitleStyle(builder);
            builder.Write("知识点微课");

            builder.InsertCell();
            builder.Font.Size = 10.5;
            builder.CellFormat.Width = 300;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
            builder.CellFormat.Borders.Right.Color = Color.White;
            builder.InsertHtml(string.Format(@"<span style='font-size:9pt;font-family:微软雅黑'>包含<span style='font-size:9pt;font-weight:bold;font-family:微软雅黑;' >{0}</span>个知识点视频</span>", 2));

            builder.InsertCell();
            builder.CellFormat.TopPadding = 3;
            builder.CellFormat.RightPadding = 5;
            builder.CellFormat.BottomPadding = 3;
            builder.CellFormat.Width = 100;
            builder.CellFormat.Borders.Right.Color = Color.LightGray;
            builder.CellFormat.Borders.Left.Color = Color.White;
            builder.InsertImage(CreateImg());
            builder.EndRow();
        }

        /// <summary>
        /// 左侧标题共有样式
        /// </summary>
        /// <param name="build"></param>
        public void LeftTitleStyle(DocumentBuilder build)
        {
            build.InsertCell();
            build.Bold = true;
            build.CellFormat.Width = 150;
            build.Font.Size = 12;
            build.CellFormat.Shading.BackgroundPatternColor = Color.White;
        }

        /// <summary>
        /// 右侧内容共有样式
        /// </summary>
        /// <param name="build"></param>
        public void RightContentStyle(DocumentBuilder build)
        {
            build.InsertCell();
            build.Bold = false;
            build.Font.Size = 10.5;
            build.CellFormat.Width = 400;
            build.CellFormat.Shading.BackgroundPatternColor = Color.White;
        }

        /// <summary>
        /// 初始化表格样式
        /// </summary>
        /// <param name="build"></param>
        public void InitTableStyle(DocumentBuilder build)
        {
            TableFormatClear(build);
            build.RowFormat.Borders.LineStyle = LineStyle.Thick;
            build.CellFormat.Borders.LineStyle = LineStyle.Thick;
            build.CellFormat.Borders.Color = Color.LightGray;
            build.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            build.CellFormat.LeftPadding = 0;
            build.CellFormat.RightPadding = 0;
            build.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            build.ParagraphFormat.LineSpacingRule = LineSpacingRule.Multiple;
            build.ParagraphFormat.LineSpacing = 12;
            build.Font.Bold = false;
            build.Font.Size = 12;
            build.Font.Name = "微软雅黑";
            build.Font.NameAscii = "Times New Roman";
        }


        /// <summary>
        /// 表格初始格式清除
        /// </summary>
        /// <param name="builder">builder</param>
        public void TableFormatClear(DocumentBuilder builder)
        {
            builder.RowFormat.ClearFormatting();
            builder.CellFormat.ClearFormatting();
        }

        /// <summary>
        /// 获取表格宽度
        /// 默认为文档宽度-分栏间距-表格层级间距
        /// 文档宽度：页面宽度-左边距-右边距-装订线
        /// 分栏间距：(栏数-1)*5
        /// 表格层级间距：表格间距+5*(层级-1)
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="level">层级，是否需要减间距</param>
        /// <returns></returns>
        public double GetTableWidth(WordWriter writer, int level = 1)
        {
            var pageSetup = writer.DocumentBuilder.Document.Sections[0].PageSetup;
            var pageWidth = pageSetup.PageWidth;
            var leftWidth = pageSetup.LeftMargin;
            var rightWidth = pageSetup.RightMargin;
            var gutter = pageSetup.Gutter;
            var count = pageSetup.TextColumns.Count;
            var docWidth = pageWidth - leftWidth - rightWidth - gutter;
            var paddingWidth = 15 * (level - 1);
            return docWidth / count - (count - 1) * 8 - paddingWidth;
        }



        public Image CreateImg()
        {
            var image = Image.FromFile(imgCodePath);
            return image;
        }

    }
}

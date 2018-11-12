using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Tables;
using RuanYun.Word.Builder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Utils工具.ASPOSE
{

    public class AsposeWord
    {
        public static void AsposeWordRemove()
        {

            string tempFile = "D:\\test.docx";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            var writer = new WordWriter(builder);
            doc.Range.Replace(new Regex("{test}"), new WordReplacer(args =>
            {
                var matchNode = args.MatchNode;
                Table tableNode = null;
                while (matchNode.ParentNode != null)
                {
                    if (matchNode.ParentNode.NodeType == NodeType.Table)
                    {
                        tableNode = (Table)matchNode.ParentNode;
                        break;
                    }
                    matchNode = matchNode.ParentNode;
                }
                if (tableNode != null)
                {
                    tableNode.LastRow.Remove();
                    var lastRow = tableNode.LastRow;
                    foreach (Cell cell in lastRow.Cells)
                    {
                        cell.CellFormat.Borders.Bottom.LineStyle = LineStyle.Single;
                        cell.CellFormat.Borders.Bottom.Color = ColorTranslator.FromHtml("#A5A5A5");
                    }
                }
            }), false);
            doc.Save("D:\\test2.docx");
        }





        public static void creat()
        {
            AsposeWordRemove();
            //RemoveNumbers();
            //HandleGuaranteeDoc("CNName", "CNName", "HAWB", "PCS", "D:\\test3.docx");
            //test();
        }



        public static void test()
        {
            string tempFile = "D:\\test.docx";
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);




            // This shows what is in the document originally. The document has two sections.
            Console.WriteLine(doc.GetText());

            // Delete the first section from the document
            doc.Sections.RemoveAt(1);

            // Duplicate the last section and append the copy to the end of the document.
            int lastSectionIdx = doc.Sections.Count - 1;
            Section newSection = doc.Sections[lastSectionIdx].Clone();
            doc.Sections.Add(newSection);

            // Check what the document contains after we changed it.
            Console.WriteLine(doc.GetText());
            doc.Save("D:\\test2.docx");

        }

        //public Table WriteWrongQuestionEvaluationInfo(DocumentBuilder writer, WrongQuestionResult wrongQuestion)
        //{
        //    var titleWidthProportion = 0.15;
        //    var rowHeight = 22.7;
        //    var builder = writer.DocumentBuilder;
        //    var tableWidth = GetTableWidth(writer);
        //    var table = builder.StartTable();
        //    InitTableStyle(builder);
        //    builder.InsertCell();
        //    builder.CellFormat.Borders.Top.Color = ColorTranslator.FromHtml("#A5A5A5");
        //    builder.CellFormat.Borders.Top.LineStyle = LineStyle.Single;
        //    builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
        //    builder.CellFormat.PreferredWidth = PreferredWidth.FromPoints(tableWidth * titleWidthProportion);
        //    builder.CellFormat.Width = tableWidth * titleWidthProportion;
        //    builder.CellFormat.Shading.BackgroundPatternColor = ColorTranslator.FromHtml("#FFFFFF");
        //    builder.RowFormat.Height = rowHeight;
        //    builder.Write("【测评统计】");
        //    builder.InsertCell();
        //    builder.CellFormat.PreferredWidth = PreferredWidth.FromPoints(tableWidth * (1 - titleWidthProportion));
        //    builder.CellFormat.Width = tableWidth * (1 - titleWidthProportion);
        //    if (wrongQuestion.AvgScoreRate.HasValue)
        //    {
        //        builder.Font.Bold = true;
        //        builder.Write("该题本次测评");
        //        builder.Font.Bold = false;
        //        builder.Write(string.Format("平均得分率{0}%，", (int)Math.Round(wrongQuestion.AvgScoreRate.Value * 100)));
        //    }
        //    builder.Font.Bold = true;
        //    builder.Write("你的");
        //    builder.Font.Bold = false;
        //    builder.Write(string.Format("得分率{0}%", (int)Math.Round(wrongQuestion.ScoreRate * 100)));
        //    builder.EndRow();
        //    builder.CellFormat.Borders.Top.LineStyle = LineStyle.None;

        //    WriteWrongQuestionKnowledgePointName(builder, wrongQuestion, tableWidth, titleWidthProportion, rowHeight);
        //    WriteWrongQuestionErrorReason(builder, tableWidth, titleWidthProportion, rowHeight);
        //    WriteWrongQuestionImproveMethod(builder, wrongQuestion, tableWidth, titleWidthProportion, rowHeight);
        //    return table;
        //}


        /// <summary>
        /// 非危保函（将指定路径的模板Path_TempleteDoc输出至Path_out路径）
        /// </summary>
        /// <param name="Path_TempleteDoc">模板文件路径，包含文件名</param>
        /// <param name="CNName">中文品名</param>
        /// <param name="ENName">英文描述</param>
        /// <param name="HAWB">HAWB</param>
        /// <param name="PCS">件数</param>
        /// <param name="Path_out">文件输出路径，包含文件名</param>
        private static void HandleGuaranteeDoc(string CNName, string ENName, string HAWB, string PCS, string Path_out)
        {
            string tempFile = "D:\\test.docx";      //获取模板路径，这个根据个人模板路径而定。
            Document doc = new Document(tempFile);
            DocumentBuilder builder = new DocumentBuilder(doc);   //操作word
            Dictionary<string, string> dic = new Dictionary<string, string>();   //创建键值对   第一个string 为书签名称 第二个string为要填充的数据
            if (!string.IsNullOrEmpty(CNName))
            {
                dic.Add("CNName", CNName);
            }
            if (!string.IsNullOrEmpty(ENName))
            {
                dic.Add("ENName", ENName);
            }
            if (!string.IsNullOrEmpty(HAWB))
            {
                dic.Add("HAWB", HAWB);
            }
            if (!string.IsNullOrEmpty(PCS))
            {
                dic.Add("PCS", PCS);
            }
            foreach (var key in dic.Keys)   //循环键值对
            {
                builder.Write(dic[key]);   //填充值
            }
            doc.Save(Path_out); //保存word
        }

        private static void RemoveNumbers()
        {
            DocumentBuilder builder = new DocumentBuilder();

            builder.Writeln("Aspose.Words allows:");
            builder.Writeln();

            // Start a numbered list with default formatting.
            builder.ListFormat.ApplyNumberDefault();
            builder.Writeln("Opening documents from different formats:");

            // Go to second list level, add more text.
            builder.ListFormat.ListIndent();
            builder.Writeln("DOC");
            builder.Writeln("PDF");
            builder.Writeln("HTML");

            // Outdent to the first list level.
            builder.ListFormat.ListOutdent();
            builder.Writeln("Processing documents");
            builder.Writeln("Saving documents in different formats:");

            // Indent the list level again.
            builder.ListFormat.ListIndent();
            builder.Writeln("DOC");
            builder.Writeln("PDF");
            builder.Writeln("HTML");
            builder.Writeln("MHTML");
            builder.Writeln("Plain text");

            // Outdent the list level again.
            builder.ListFormat.ListOutdent();
            builder.Writeln("Doing many other things!");

            // End the numbered list.
            builder.ListFormat.RemoveNumbers();
            builder.Writeln();

            builder.Writeln("Aspose.Words main advantages are:");
            builder.Writeln();

            // Start a bulleted list with default formatting.
            builder.ListFormat.ApplyBulletDefault();
            builder.Writeln("Great performance");
            builder.Writeln("High reliability");
            builder.Writeln("Quality code and working");
            builder.Writeln("Wide variety of features");
            builder.Writeln("Easy to understand API");

            // End the bulleted list.
            builder.ListFormat.RemoveNumbers();

            builder.Document.Save("D:\\Lists.ApplyDefaultBulletsAndNumbers Out.doc");


        }

    }

    public class InsertDocumentAtReplaceHandler : IReplacingCallback
    {
        public string MyDir = "D:\\";

        public void InsertDocumentAtReplace()
        {
            //Document mainDoc = new Document(MyDir + "test.docx");
            //mainDoc.Range.Replace(new Regex("\\[MY_DOCUMENT\\]"), new InsertDocumentAtReplaceHandler(), false);
            //mainDoc.Save(MyDir + "InsertDocumentAtReplace Out.doc");
        }
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            //Document subDoc = new Document(MyDir + "InsertDocument2.doc");

            // Insert a document after the paragraph, containing the match text. 在段落之后插入一个包含匹配文本的文档
            //Paragraph para = (Paragraph)e.MatchNode.ParentNode;
            //InsertDocument(para, subDoc);

            // Remove the paragraph with the match text.
            //para.Remove();
            var matchNode = e.MatchNode;
            Table tableNode = null;
            while (matchNode.ParentNode != null)
            {
                if (matchNode.ParentNode.NodeType == NodeType.Table)
                {
                    tableNode = (Table)matchNode.ParentNode;
                    break;
                }
                matchNode = matchNode.ParentNode;
            }
            if (tableNode != null)
            {
                tableNode.Rows[tableNode.Rows.Count - 2].RowFormat.Borders.Bottom.LineStyle = LineStyle.Single;
                tableNode.Rows[tableNode.Rows.Count - 2].RowFormat.Borders.Bottom.Color = ColorTranslator.FromHtml("#A5A5A5");
                tableNode.LastRow.Remove();
                //tableNode.Rows.RemoveAt(tableNode.Rows.Count - 1);
                //tableNode.Rows[tableNode.Rows.Count - 1].RowFormat.Borders.Bottom.LineStyle = LineStyle.Single;
                //tableNode.LastRow.RowFormat.Borders.Bottom.LineStyle = LineStyle.Single;
                //  tableNode.LastRow.RowFormat.Borders.Bottom.Color = ColorTranslator.FromHtml("#A5A5A5");
                //builder.CellFormat.Borders.Bottom.Color = ColorTranslator.FromHtml("#A5A5A5");
                //builder.CellFormat.Shading.BackgroundPatternColor = ColorTranslator.FromHtml("#EDEDED");


            }
            return ReplaceAction.Skip;
        }
    }
}

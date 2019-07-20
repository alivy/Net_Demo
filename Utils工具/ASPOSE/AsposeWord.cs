using AForge.Imaging.Filters;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Replacing;
using Aspose.Words.Tables;
using RuanYun.Word;
using RuanYun.Word.Builder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Utils工具.MyMindFusion;
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
#pragma warning disable CS0618 // 类型或成员已过时
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
                    Row lastRow = tableNode.LastRow;
                    foreach (Cell cell in lastRow.Cells)
                    {
                        cell.CellFormat.Borders.Bottom.LineStyle = LineStyle.Single;
                        cell.CellFormat.Borders.Bottom.Color = ColorTranslator.FromHtml("#A5A5A5");
                    }
                }
            }), false);
#pragma warning restore CS0618 // 类型或成员已过时
            doc.Save("D:\\test2.docx");
        }

        /// <summary>
        /// 设置图片只有两色
        /// </summary>
        public static void SetImgTwoColors()
        {
            string tempFile = "F:\\TFCTest\\new\\test.docx";
            Document doc = new Document(tempFile);
            var shapes = doc.GetChildNodes(NodeType.Shape, true);
            foreach (var shape in shapes)
            {
                var img = ((Shape)shape).ImageData.ToImage();
                using (var bitmap = new Bitmap(img))
                using (var backBitmap = ReplaceBackgroundColor(bitmap, Color.White))
                using (var clearColor = ToGray(backBitmap))
                {
                    clearColor.Save("F:\\TFCTest\\new\\testimg\\" + Guid.NewGuid().ToString() + ".png");
                    ((Shape)shape).ImageData.ImageBytes = PhotoImageInsert(clearColor);
                }
            }
            doc.Save(@"F:\\TFCTest\\new\\test2.docx");
        }

        //将Image转换成流数据，并保存为byte[] 
        public static byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            using (MemoryStream mstream = new MemoryStream())
            {
                imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] byData = new Byte[mstream.Length];
                mstream.Position = 0;
                mstream.Read(byData, 0, byData.Length);
                return byData;
            }
        }





        public static System.Drawing.Image BlackWhitePhoto(System.Drawing.Image images)
        {
            try
            {
                Bitmap map = new Bitmap(images);
                Bitmap bitmap = new Bitmap(images.Width, images.Height);
                if (bitmap.PixelFormat != PixelFormat.Format8bppIndexed)
                {
                    bitmap = Grayscale.CommonAlgorithms.BT709.Apply(map);
                    //Grayscale g = new Grayscale(0.2125, 0.7154, 0.0721);
                    //bitmap = g.Apply(map);
                }
                BradleyLocalThresholding filter = new BradleyLocalThresholding();
                filter.ApplyInPlace(bitmap);
                return bitmap;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>  
        /// 图像灰度化  
        /// </summary>  
        /// <param name="bmp"></param>  
        /// <returns></returns>  
        public static Bitmap ToGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }

        public static void RaplaceTransparentColor(System.Drawing.Image image)
        {

            using (Bitmap bitmap = new Bitmap(image))
            {
                var g = Graphics.FromImage(bitmap);
                g.Clear(Color.Green);
                //bitmap.MakeTransparent(Color.Green);
                bitmap.Save("E:\\BlackWhitePhoto\\错误图片1.png");
            }
        }





        /// <summary>
        /// 设置图片为黑白色
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static System.Drawing.Image BlackWhitePhoto(Bitmap map)
        {
            if (map.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                var bitmap = ReplaceBackgroundColor(map, Color.White);
                Grayscale g = new Grayscale(0.2125, 0.7154, 0.0721);
                bitmap = g.Apply(bitmap);
                BradleyLocalThresholding filter = new BradleyLocalThresholding();
                filter.ApplyInPlace(bitmap);
                return bitmap;
            }
            return map;
        }


        /// <summary>
        /// 设置图片为黑白色
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ReplaceBackgroundColor(Bitmap map, Color color)
        {
            var bitmap = new Bitmap(map.Width, map.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(color);
                graphics.DrawImage(map, new Point(0, 0));
                graphics.Save();
            }
            return bitmap;
        }



        /// <summary>
        /// 将png图片插入word
        /// </summary>
        public static void AsposeWordReplaceImg()
        {
            string logoPath = "F:\\错误图片.png";
            System.Drawing.Image image = System.Drawing.Image.FromFile(logoPath);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.DrawImage(image, new Point(0, 0));
                graphics.ResetTransform();
                graphics.Save();
            }
            string url = string.Format(@"F:\testxx.png");
            using (var ms = GetStreamFromBitmap(bitmap))
            using (var imgto = System.Drawing.Image.FromStream(ms))
            {
                imgto.Save(url, ImageFormat.Png);
            }


        }


        public static void AsposeWordInsetImg()
        {
            string tempFile = "F:\\TFCTest\\old\\test.docx";
            // Document doc = new Document(tempFile);
            // DocumentBuilder builder = new DocumentBuilder(doc);
            //var writer = new WordWriter(builder);
            var document = WordFactory.CreateBuilder(tempFile);
            WordWriteImage(document);
            //ReplaceImg(document, "{StudentName}");
            document.Save("F:\\TFCTest\\new\\test.docx");
        }

        /// <summary>
        /// 将图片写入文档中
        /// </summary>
        /// <param name="document"></param>
        public static void WordWriteImage(IWordBuilder document)
        {
            for (int i = 1; i < 19; i++)
            {
                string path = "F:\\TFCTest\\new\\img\\40060_" + i + ".png";
                System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                document.Writer.WriteImage(image);
            }
        }



        public static void ReplaceImg(IWordBuilder wordBuilder, string replaceConcent)
        {
            wordBuilder.ReplaceCallBack("replaceConcent", act =>
            {
                act.WriteImage(NatureGraphics());
                act.InsertBreak(BreakType.PageBreak);
            });

        }





        public static MemoryStream GetStreamFromBitmap(Bitmap bitmap)
        {
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            return stream;
        }



        public static void NewGraphics()
        {
            string logoPath = "F:\\错误图片.png";
            System.Drawing.Image image = System.Drawing.Image.FromFile(logoPath);
            Bitmap bitmap = new Bitmap(1000, 1000); ;
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Green);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.DrawImage(image, new Point(100, 10));
                graphics.ResetTransform();
                graphics.Save();

            }
            bitmap.Save("E:\\错误图片.png");
            //return bitmap;
        }


        public static System.Drawing.Image NatureGraphics()
        {
            string logoPath = "F:\\testx.png";
            //System.Drawing.Image image = System.Drawing.Image.FromFile(logoPath);
            Bitmap bitmapLogo = new Bitmap(logoPath);
            bitmapLogo.MakeTransparent(Color.White);
            System.Drawing.Image imageLogo = GetThumbnailByHeight(bitmapLogo, 60);
            return imageLogo;
        }


        /// <summary>
        /// 获取缩略图,按比例缩放     
        /// </summary>
        /// <param name="b"></param>
        /// <param name="destHeight"></param>
        /// <param name="destWidth"></param>
        /// <returns></returns>
        public static Bitmap GetThumbnail(Bitmap b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按缩放比例计算长和宽          
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(sW, sH);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量         
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle(0, 0, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量     
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }

        /// <summary>
        /// 通过高度等比缩放图片
        /// </summary>
        /// <param name="b"></param>
        /// <param name="destHeight"></param>
        /// <returns></returns>
        public static Bitmap GetThumbnailByHeight(Bitmap b, int destHeight)
        {
            return GetThumbnail(b, destHeight, 10000);
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

        public void Process(WordWriter writer)
        {
            writer.DocumentBuilder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            List<ExamQuestionAtlasChart.ExamQuestionNodeInfo> questions = new List<ExamQuestionAtlasChart.ExamQuestionNodeInfo>();
            questions.AddRange(GetExamQuestionNodeInfo(1, "知识点名称1", 1, 4));
            questions.AddRange(GetExamQuestionNodeInfo(2, "知识点名称2", 5, 5));
            questions.AddRange(GetExamQuestionNodeInfo(3, "知识点名称3", 10, 2));
            questions.AddRange(GetExamQuestionNodeInfo(4, "知识点名称4", 12, 8));
            questions.AddRange(GetExamQuestionNodeInfo(5, "知识点名称5", 20, 1));
            questions.AddRange(GetExamQuestionNodeInfo(6, "知识点名称6", 21, 2));
            var plotter = new ExamQuestionAtlasChart(questions);
            Utility.Retry(() =>
            {
                using (var stream = plotter.Draw())
                {
                    writer.DocumentBuilder.Font.Size = 10.5;
                    writer.DocumentBuilder.Font.Color = ColorTranslator.FromHtml("#00A0e9");
                    writer.InsertBreak();
                    var shape = writer.WriteImage(stream);
                    var maxWidth = 500;
                    var maxHeight = 700;
                    if (shape.Height > maxHeight || shape.Width > maxWidth)
                    {
                        var scaling = Math.Max(shape.Height / maxHeight, shape.Width / maxWidth);
                        shape.Height /= scaling;
                        shape.Width /= scaling;
                    }
                    writer.InsertBreak(BreakType.PageBreak);
                }
            }, 3, 300);
        }

        /// <summary>
        /// 获取考试试卷题目
        /// </summary>
        /// <param name="knowledgePointId"></param>
        /// <param name="knowledgePointName"></param>
        /// <param name="stratQestionNumber"></param>
        /// <param name="questionCount"></param>
        /// <returns></returns>
        private List<ExamQuestionAtlasChart.ExamQuestionNodeInfo> GetExamQuestionNodeInfo(int knowledgePointId, string knowledgePointName, int stratQestionNumber, int questionCount)
        {
            var _r = new Random(DateTime.Now.Millisecond);
            var result = new List<ExamQuestionAtlasChart.ExamQuestionNodeInfo>();
            for (var i = 0; i < questionCount; i++)
            {
                result.Add(new ExamQuestionAtlasChart.ExamQuestionNodeInfo
                {
                    KnowledgePointId = knowledgePointId,
                    KnowledgePointName = knowledgePointName,
                    QuestionNumber = stratQestionNumber + i,
                    QuestionBaseScore = _r.Next(0, 5) * 4,
                    QuestionScoreRate = _r.NextDouble()
                });
            }

            return result;
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
    /// <summary>
    /// 方法扩展
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// 提供可重试的调用方式
        /// <para>如果执行成功直接返回</para>
        /// <para>尝试次数达到上限后依旧失败，将最后一次执行的异常抛出</para>
        /// </summary>
        /// <param name="action">执行的操作</param>
        /// <param name="count">失败重试次数的上限</param>
        /// <param name="sleep"></param>
        public static void Retry(Action action, uint count = 3, int sleep = 5000)
        {
            if (action == null) return;
            if (count == 0)
                return;
            try
            {
                action();
            }
            catch
            {
                Thread.Sleep(sleep);
                count--;
                if (count == 0)
                    throw;
                Retry(action, count, sleep);
            }
        }

        /// <summary>
        /// 匿名方法递归
        /// </summary>
        /// <typeparam name="T">匿名方法输入参数类型</typeparam>
        /// <typeparam name="TResult">匿名方法返回类型</typeparam>
        /// <param name="func">匿名方法委托</param>
        /// <returns></returns>
        public static Func<T, TResult> Fix<T, TResult>(Func<Func<T, TResult>, Func<T, TResult>> func)
        {
            return x => func(Fix(func))(x);
        }

        /// <summary>
        /// 匿名方法递归
        /// </summary>
        /// <typeparam name="T1">匿名方法第一个输入参数类型</typeparam>
        /// <typeparam name="T2">匿名方法第二个输入参数类型</typeparam>
        /// <typeparam name="TResult">匿名方法返回类型</typeparam>
        /// <param name="func">匿名方法委托</param>
        /// <returns></returns>
        public static Func<T1, T2, TResult> Fix<T1, T2, TResult>(Func<Func<T1, T2, TResult>, Func<T1, T2, TResult>> func)
        {
            return (x, y) => func(Fix(func))(x, y);
        }

        /// <summary>
        /// like查询字符转义
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public static string SqlLikeReplace(string keyWord)
        {
            if (string.IsNullOrWhiteSpace(keyWord))
            {
                return keyWord;
            }
            if (keyWord.Contains("%"))
            {
                return keyWord.Replace("%", @"\%");
            }
            if (keyWord.Contains("_"))
            {
                return keyWord.Replace("_", @"\_");
            }
            if (keyWord.Contains("'"))
            {
                return keyWord.Replace("'", "\'");
            }
            if (keyWord.Contains(@"\"))
            {
                return keyWord.Replace(@"\", @"\\\\");
            }
            return keyWord;
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

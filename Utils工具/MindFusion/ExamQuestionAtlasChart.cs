using MindFusion.Diagramming;
using MindFusion.Diagramming.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindFusion.Layout;
using LinearGradientBrush = MindFusion.Drawing.LinearGradientBrush;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Utils工具.MyMindFusion
{
    public class ExamQuestionAtlasChart : PicBase
    {

        #region 知识点掌握水平填充颜色

        /// <summary>
        /// 知识点掌握水平：0%～50%
        /// </summary>
        private static readonly Color _colorOfScoreRateLevel1 = Color.FromArgb(0xE0, 0x4D, 0x5B);

        /// <summary>
        /// 知识点图片颜色，知识点掌握水平：50%～70%
        /// </summary>
        private static readonly Color _colorOfScoreRateLevel2 = Color.FromArgb(0x8D, 0xC8, 0xFF);

        /// <summary>
        /// 知识点图片颜色，知识点掌握水平：70%～100%
        /// </summary>
        private static readonly Color _colorOfScoreRateLevel3 = Color.FromArgb(0xE4, 0xF7, 0xE3);

        /// <summary>
        /// 知识点图片颜色，知识点掌握水平：知识点未覆盖
        /// </summary>
        private static readonly Color _colorOfScoreRateLevel4 = Color.White;

        #endregion

        /// <summary>
        /// 试卷中题目信息集合
        /// </summary>
        private List<ExamQuestionNodeInfo> _examQuestionInformations;

        /// <summary>
        /// 知识点描述信息
        /// </summary>
        public List<KnowledgePointDescription> _knowledgePointDescription;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="examQuestionInformations"></param>
        public ExamQuestionAtlasChart(List<ExamQuestionNodeInfo> examQuestionInformations)
            : base(string.Empty, 0, 0)
        {
            if (examQuestionInformations == null || examQuestionInformations.Count == 0)
            {
                throw new ArgumentException("Can't be empty or null", "examQuestionInformations&topics");
            }
            _examQuestionInformations = examQuestionInformations;
            var index = 1;
            _knowledgePointDescription = examQuestionInformations.GroupBy(x => x.KnowledgePointId).OrderBy(x => x.Key).Select(x =>
                new KnowledgePointDescription { PointId = x.Key, PointCode = "K" + index++, PointName = x.First().KnowledgePointName }).ToList();
        }

        /// <summary>
        /// 生成图片逻辑
        /// </summary>
        public override MemoryStream Draw()
        {
            using (var diagram = CreateDiagram())
            {
                var tuple = BuildExamQuestionAtlas(diagram);
                ApplyLayout(diagram);
                using (var bitmap = diagram.CreateImage())
                using (var newBitmap = ClearExtraWhiteSpace(bitmap))
                {
                    GetStreamFromBitmap(newBitmap);

                    DisposeObject(tuple.Item1.ToArray());
                    DisposeObject(tuple.Item2.ToArray());

                    return SynthesisImg(newBitmap);
                }
            }
        }


        /// <summary>
        /// 清空bitmap对象的下方和右侧的空白区域
        /// </summary>
        /// <param name="bitmap">bitmap对象</param>
        /// <returns>清空下方和右侧的空白区域后的bitmap对象</returns>
        public static Bitmap ClearExtraWhiteSpace(Bitmap bitmap)
        {
            var boundaryWhiteWidth = 5;

            var realWidth = CalculateBitmapRealWidth(bitmap);
            realWidth = Math.Min(bitmap.Width, realWidth + boundaryWhiteWidth);

            var realHeight = CalculateBitmapRealHeight(bitmap);
            realHeight = Math.Min(bitmap.Height, realHeight + boundaryWhiteWidth);

            return bitmap.Clone(new Rectangle(0, 0, realWidth, realHeight), bitmap.PixelFormat);
        }

        /// <summary>
        /// 计算bitmap对象的内容真实高度。
        /// 从下往上，找到底部为空白的宽度
        /// </summary>
        /// <param name="bitmap">bitmap对象</param>
        /// <returns>真实内容的高度</returns>
        private static int CalculateBitmapRealHeight(Bitmap bitmap)
        {
            var whiteColor = Color.White;
            var step = 3;
            var realHeight = bitmap.Height;
            for (var i = bitmap.Height - 1; i >= 0; i -= step)
            {
                var notWhite = false;
                for (var j = 0; j < bitmap.Width; j += step)
                {
                    var color = bitmap.GetPixel(j, i);
                    if (color.R != whiteColor.R || color.G != whiteColor.G || color.B != whiteColor.B)
                    {
                        notWhite = true;
                        break;
                    }
                }
                if (notWhite)
                {
                    break;
                }
                realHeight = i;
            }
            return realHeight;
        }

        /// <summary>
        /// 计算bitmap对象的内容真实宽度。
        /// 从下往上，找到右侧为空白的宽度
        /// </summary>
        /// <param name="bitmap">bitmap对象</param>
        /// <returns>真实内容的宽度</returns>
        private static int CalculateBitmapRealWidth(Bitmap bitmap)
        {
            var whiteColor = Color.White;
            var step = 3;
            var realWidth = bitmap.Width;
            for (var i = bitmap.Width - 1; i >= 0; i -= step)
            {
                var notWhite = false;
                for (var j = 0; j < bitmap.Height; j += step)
                {
                    var color = bitmap.GetPixel(i, j);
                    if (color.R != whiteColor.R || color.G != whiteColor.G || color.B != whiteColor.B)
                    {
                        notWhite = true;
                        break;
                    }
                }
                if (notWhite)
                {
                    break;
                }
                realWidth = i;
            }
            return realWidth;
        }
        /// <summary>
        /// 构建考试题目图谱关系
        /// </summary>
        /// <param name="diagram"></param>
        /// <returns></returns>
        private Tuple<List<ShapeNode>, List<DiagramLink>> BuildExamQuestionAtlas(Diagram diagram)
        {
            var nodeMap = new Dictionary<int, ShapeNode>();
            var links = new List<DiagramLink>();
            var relationMap = new Dictionary<int, List<int>>();
            var knowledgePointGroups = _examQuestionInformations.GroupBy(x => x.KnowledgePointId);
            foreach (var knowledgePointGroup in knowledgePointGroups)
            {
                var knowledgePointDesc = _knowledgePointDescription.FirstOrDefault(x => x.PointId == knowledgePointGroup.Key);
                var questionInformations = knowledgePointGroup.ToList();
                foreach (var questionInfo in questionInformations)
                {
                    if (!nodeMap.ContainsKey(questionInfo.QuestionNumber))
                    {
                        nodeMap.Add(questionInfo.QuestionNumber, CreateShapeNode(diagram, GetQuestionNodeColor(questionInfo.QuestionScoreRate), CalculateQuestionNodeWidth(questionInfo.QuestionBaseScore), questionInfo.QuestionNumber.ToString()));
                    }
                    var startNode = nodeMap[questionInfo.QuestionNumber];
                    var relationiQuestionInformations = questionInformations.Where(x => x.QuestionNumber != questionInfo.QuestionNumber);
                    foreach (var relationiQuestion in relationiQuestionInformations)
                    {
                        if (!nodeMap.ContainsKey(relationiQuestion.QuestionNumber))
                        {
                            nodeMap.Add(relationiQuestion.QuestionNumber, CreateShapeNode(diagram, GetQuestionNodeColor(relationiQuestion.QuestionScoreRate), CalculateQuestionNodeWidth(relationiQuestion.QuestionBaseScore), relationiQuestion.QuestionNumber.ToString()));
                        }
                        var stopNode = nodeMap[relationiQuestion.QuestionNumber];
                        if ((relationMap.ContainsKey(questionInfo.QuestionNumber) && relationMap[questionInfo.QuestionNumber].Contains(relationiQuestion.QuestionNumber))
                            || (relationMap.ContainsKey(relationiQuestion.QuestionNumber) && relationMap[relationiQuestion.QuestionNumber].Contains(questionInfo.QuestionNumber)))
                        {
                            continue;
                        }
                        if (!relationMap.ContainsKey(questionInfo.QuestionNumber))
                        {
                            relationMap.Add(questionInfo.QuestionNumber, new List<int>());
                        }
                        relationMap[questionInfo.QuestionNumber].Add(relationiQuestion.QuestionNumber);
                        links.Add(CreateDiagramLink(diagram, startNode, stopNode, knowledgePointDesc == null ? "" : knowledgePointDesc.PointCode));
                    }
                }
            }
            return new Tuple<List<ShapeNode>, List<DiagramLink>>(nodeMap.Select(x => x.Value).ToList(), links);
        }

        private void ApplyLayout(Diagram diagram)
        {
            var layout = new TopologicalLayout();
            layout.Orientation = MindFusion.Diagramming.Layout.Orientation.Vertical; //获取或设置所布置图的总体方向。
            layout.MultipleGraphsPlacement = MultipleGraphsPlacement.MinimalArea; //获取或设置一个值，该值指示关系图中的多个独立图应如何相对定位。
            layout.GrowToFit = true;
            layout.BendAdjacentLinks = true;
            layout.EnableParallelism = true;
            layout.NodeDistance = 10.0f; //获取或设置图中相邻节点之间的距离。
            layout.Anchoring = Anchoring.Keep; //获取或设置一个值，该值指示如何将链接与图形节点的锚点对齐。
            layout.EnableParallelism = true; //获取或设置一个值，该值指示是否在不同的线程上排列子图。
            layout.Arrange(diagram); //获取布局的用户友好名称
        }

        private Diagram CreateDiagram()
        {
            //初始化布局
            var diagram = new Diagram();
            // ShapeNodeStyle 表示定义形状节点外观的一组可重用属性。
            // Brush 获取或设置用于填充项内部的笔刷。
            diagram.ShapeNodeStyle.Brush = new MindFusion.Drawing.LinearGradientBrush(Color.Black, Color.Red, 3);
            //SolidBrush类充当.NET标准GDI+System.Drawing.SolidBrush类的代理    
            diagram.BackBrush = new MindFusion.Drawing.SolidBrush(Color.FromArgb(224, 233, 233));
            //获取或设置形状节点的默认形状。 Shapes.Ellipse
            diagram.DefaultShape = Shapes.Cube;
            diagram.LinkCrossings = LinkCrossings.Arcs;
            diagram.AutoResize = AutoResize.RightAndDown;
            diagram.BackBrush = new MindFusion.Drawing.SolidBrush(Color.White);
            diagram.Bounds = new RectangleF(0, 0, 180, 250);
            diagram.AllowMultipleResize = false;
            diagram.AutoResize = AutoResize.RightAndDown;
            return diagram;
        }


        /// <summary>
        /// 合并图片
        /// </summary>
        /// <param name="examQuestionImage">考试图谱图片对象</param>
        public MemoryStream SynthesisImg(Bitmap examQuestionImage)
        {
            int baseWidth = 720;
            int baseHight = 1000;
            int minWidth = 260;
            int maxWidth = 400;
            double aspectRatio = baseWidth * 1.0 / baseHight;
            double ratio = examQuestionImage.Width * 1.0 / (examQuestionImage.Height * 1.0);
            bool rightImg = ratio <= aspectRatio;
            using (var examInstructionsInfo = ExamInstructionsInfo(examQuestionImage))
            {
                var descriptionWidth = 0;
                if (rightImg)
                {
                    var diffWidth = baseWidth - examQuestionImage.Width;
                    descriptionWidth = Math.Max(Math.Min(diffWidth, maxWidth), minWidth);
                }
                else
                {
                    descriptionWidth = examQuestionImage.Width < minWidth ? minWidth : examQuestionImage.Width;
                }
                using (var knowledgeDescription = CreateKnowledgeDescriptionImg(descriptionWidth))
                {
                    return CreateLayoutImg(examQuestionImage, examInstructionsInfo, knowledgeDescription, rightImg);
                }
            }
        }
        /// <summary>
        /// 布局创建图片
        /// </summary>
        /// <param name="examQuestionImage">知识点关联关系图</param>
        /// <param name="examInstructionsInfo">知识点掌握水平图</param>
        /// <param name="knowledgeDescription">知识点说明图</param>
        /// <param name="rightImg">bmp2，bmp3是否在右边</param>
        public MemoryStream CreateLayoutImg(Bitmap examQuestionImage, Bitmap examInstructionsInfo, Bitmap knowledgeDescription, bool rightImg = false)
        {
            int width, height;
            if (rightImg)
            {
                width = examQuestionImage.Width + knowledgeDescription.Width;
                height = examQuestionImage.Height > examInstructionsInfo.Height + knowledgeDescription.Height ? examQuestionImage.Height : examInstructionsInfo.Height + knowledgeDescription.Height + 20;
            }
            else
            {
                width = examQuestionImage.Width + 10;
                height = examQuestionImage.Height + examInstructionsInfo.Height + knowledgeDescription.Height + 20;
            }
            using (var bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawImage(examQuestionImage, new Rectangle(0, 0, examQuestionImage.Width, examQuestionImage.Height), new Rectangle(0, 0, examQuestionImage.Width, examQuestionImage.Height), GraphicsUnit.Pixel);
                    if (rightImg)
                    {
                        g.DrawImage(examInstructionsInfo, new Rectangle(examQuestionImage.Width, 10, examInstructionsInfo.Width, examInstructionsInfo.Height), new Rectangle(0, 0, examInstructionsInfo.Width, examInstructionsInfo.Height), GraphicsUnit.Pixel);
                        g.DrawImage(knowledgeDescription, new Rectangle(examQuestionImage.Width, examInstructionsInfo.Height + 10, knowledgeDescription.Width, knowledgeDescription.Height), new Rectangle(0, 0, knowledgeDescription.Width, knowledgeDescription.Height), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(examInstructionsInfo, new Rectangle(0, examQuestionImage.Height, examInstructionsInfo.Width, examInstructionsInfo.Height), new Rectangle(0, 0, examInstructionsInfo.Width, examInstructionsInfo.Height), GraphicsUnit.Pixel);
                        g.DrawImage(knowledgeDescription, new Rectangle(0, examQuestionImage.Height + examInstructionsInfo.Height, knowledgeDescription.Width, knowledgeDescription.Height), new Rectangle(0, 0, knowledgeDescription.Width, knowledgeDescription.Height), GraphicsUnit.Pixel);
                    }
                    return GetStreamFromBitmap(bmp);
                };
            }
        }

        /// <summary>
        /// 生产知识掌握水平说明图片
        /// </summary>
        /// <returns></returns>
        public Bitmap ExamInstructionsInfo(Bitmap newBitmap)
        {
            return newBitmap;
            //return ChartResource.ExamInstructionsInfo; ;
        }


        /// <summary>
        /// 创建知识点说名图片
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public Bitmap CreateKnowledgeDescriptionImg(int width)
        {

            var height = 2000;
            int actualHeight = 0;
            Bitmap bitmap = new Bitmap(width, height); ;
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                graphics.ResetTransform();
                CreateDescription(graphics, bitmap.Width, out actualHeight);
                graphics.Save();
            }
            actualHeight = actualHeight > height ? height : actualHeight;
            Rectangle rClipRect = new Rectangle(0, 0, width, actualHeight);
            var map = bitmap.Clone(rClipRect, bitmap.PixelFormat);
            return map;
        }


        /// <summary>
        /// 绘制知识点说明
        /// </summary>
        /// <param name="graphic"></param>
        /// <param name="imageWidth"></param>
        /// <param name="actualHeight"></param>
        /// <param name="itemPerLine"></param>
        private void CreateDescription(Graphics graphic, int imageWidth, out int actualHeight, int itemPerLine = 3)
        {
            var avgItemPixel = imageWidth / itemPerLine;
            var lineHeight = 25;
            var yPosition = 3;
            var xBlank = 3;
            var itemCountOfLine = 0;
            var usedPixelForLine = 0;
            for (var i = 0; i < _knowledgePointDescription.Count; i++)
            {
                var knowledgeName = string.Format(@"{0}:{1}", _knowledgePointDescription[i].PointCode, _knowledgePointDescription[i].PointName);
                var knowledgePixelLength = CalculateStringPixelLength(knowledgeName);
                var knowledgePointLayoutWidth = Math.Min((int)Math.Ceiling(knowledgePixelLength * 1.0 / avgItemPixel) * avgItemPixel, imageWidth);
                var knowledgePointLayoutHeight = (int)(Math.Ceiling(knowledgePixelLength * 1.0 / imageWidth)) * lineHeight;
                if (itemCountOfLine >= 0 && usedPixelForLine + knowledgePixelLength > imageWidth - 3)
                {
                    itemCountOfLine = 0;
                    usedPixelForLine = 0;
                    yPosition += lineHeight;
                }
                graphic.DrawString(knowledgeName, new Font("华文楷体", 14f), new System.Drawing.SolidBrush(Color.Black),
                    new RectangleF(usedPixelForLine + xBlank, yPosition, knowledgePointLayoutWidth, knowledgePointLayoutHeight));
                itemCountOfLine++;
                usedPixelForLine += knowledgePointLayoutWidth;
                if (itemCountOfLine >= itemPerLine || usedPixelForLine >= imageWidth)
                {
                    itemCountOfLine = 0;
                    usedPixelForLine = 0;
                    yPosition += knowledgePointLayoutHeight;
                }
            }
            actualHeight = yPosition + lineHeight; ;
        }

        public Bitmap DrawStrings(int imageWidth, int itemPerLine, List<string> texts)
        {
            var avgItemPixel = imageWidth / itemPerLine;
            var lineHeight = 16;
            var yPosition = 3;
            var xBlank = 5;
            using (var image = new Bitmap(imageWidth, 200))
            using (var graphic = Graphics.FromImage(image))
            {
                var itemCountOfLine = 0;
                var usedPixelForLine = 0;
                foreach (var text in texts)
                {
                    var textPixelLength = CalculateStringPixelLength(text);
                    var textLayoutWidth = Math.Min((int)Math.Ceiling(textPixelLength * 1.0 / avgItemPixel) * avgItemPixel, imageWidth);
                    var textLayoutHeight = (int)(Math.Ceiling(textPixelLength * 1.0 / imageWidth)) * lineHeight;
                    if (itemCountOfLine > 0 && usedPixelForLine + textPixelLength + xBlank > imageWidth)
                    {
                        itemCountOfLine = 0;
                        usedPixelForLine = 0;
                        yPosition += lineHeight;
                    }
                    graphic.DrawString(text, new Font("宋体", 11f), new SolidBrush(Color.Black), new RectangleF(usedPixelForLine + xBlank, yPosition, textLayoutWidth, textLayoutHeight));
                    itemCountOfLine++;
                    usedPixelForLine += textLayoutWidth;
                    if (itemCountOfLine >= itemPerLine || usedPixelForLine >= imageWidth)
                    {
                        itemCountOfLine = 0;
                        usedPixelForLine = 0;
                        yPosition += textLayoutHeight;
                    }
                }
                var bitmap = image.Clone(new RectangleF(0, 0, imageWidth, Math.Min(200, yPosition + (itemCountOfLine <= 0 ? 0 : lineHeight))), image.PixelFormat);
                return bitmap;
            }
        }
        /// <summary>
        /// 计算知识点的像素长度
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <returns>行文本对象集合</returns>
        private int CalculateStringPixelLength(string text)
        {
            int charCount = 0;
            var pixelOfChar = 6;
            for (int i = 0; i < text.Length; i++)
            {
                charCount += text[i] > 255 ? 2 : 1;
            }
            return charCount * pixelOfChar;
        }

        /// <summary>
        /// 获取bitMap文件流
        /// </summary>
        /// <param name="bitmap">BitMap文件</param>
        /// <returns>MemoryStream.</returns>
        public new MemoryStream GetStreamFromBitmap(Bitmap bitmap)
        {
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            return stream;
        }

        private void DisposeObject(params IDisposable[] disposableObjects)
        {
            if (disposableObjects != null && disposableObjects.Length > 0)
            {
                foreach (var obj in disposableObjects)
                {
                    if (obj != null)
                    {
                        obj.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="diagram"></param>
        /// <param name="width"></param>
        /// <param name="topicName"></param>
        /// <param name="color"></param>
        /// <returns>新创建的节点对象</returns>
        private ShapeNode CreateShapeNode(Diagram diagram, Color color, int width = 10, string topicName = "")
        {
            var diagramNode = diagram.Factory.CreateShapeNode(new RectangleF(0, 0, 30, 30));
            diagramNode.ImageAlign = MindFusion.Drawing.ImageAlign.Center;// 获取或设置此形状节点中显示的图像的对齐方式。
            diagramNode.ZIndex = 0;                            //获取或设置此项的z顺序位置。 （继承自Diagram Item。）
            diagramNode.Font = new Font(FontFamily.GenericSansSerif, 12); // 获取或设置用于呈现节点文本的字体。
            diagramNode.HandlesStyle = HandlesStyle.Invisible;
            diagramNode.Pen = new MindFusion.Drawing.Pen(Color.FromArgb(102, 102, 102), 0.4f); //获取或设置用于绘制项目框架的笔。 （继承自Diagram Item。）
            diagramNode.Pen.LineJoin = LineJoin.Round; //指定如何在图形（子路径）中联接连续的直线或曲线段
            diagramNode.Pen.DashStyle = DashStyle.Solid; //对象绘制的虚线的样式。
            diagramNode.Shape = Shapes.Ellipse; //获取或设置对节点的几何形状定义的引用
            diagramNode.Brush = new MindFusion.Drawing.SolidBrush(color); //获取或设置用于填充此项内部的画笔。 （继承自Diagram Item。）
            diagramNode.EnableStyledText = true; //获取或设置一个值，该值指示是否启用样式化文本呈现。
            diagramNode.FlipX = true; // 获取或设置一个值，该值指示节点的形状是否水平翻转。
            diagramNode.CustomDraw = CustomDraw.Additional2; //获取或设置在此形状节点上执行的自定义绘图的类型。
            //允许将约束应用于节点的位置和大小。 （继承自Diagram Node。）
            diagramNode.Constraints = new NodeConstraints
            {
                MoveDirection = DirectionConstraint.Horizontal,
                MaxWidth = 100,
                MaxHeight = 100,
                MinHeight = 100,
                MinWidth = 100,
                KeepInsideParent = true,
                KeepRatio = true,
                DisableMirroring = true,
                KeepInsideDiagram = true
            };
            diagramNode.ShadowOffsetX = 0.0f; //获取或设置此项目阴影的水平偏移量。 （继承自Diagram Item。）
            diagramNode.ShadowOffsetY = 0.0f;//获取或设置此项目阴影的垂直偏移量。 （继承自Diagram Item。）
            diagramNode.Transparent = false;// 获取或设置一个值，该值指示此形状节点是否透明。
            diagramNode.Text = topicName; //获取或设置形状节点内显示的文本。 //中文显示有问题
            diagramNode.Bounds = new RectangleF(0, 0, width, width);
            return diagramNode;
        }


        /// <summary>
        /// 创建节点之间链接
        /// </summary>
        /// <param name="diagram"></param>
        /// <param name="startNode">链接开始节点对象</param>
        /// <param name="stopNode">链接结束节点对象</param>
        /// <param name="text"></param>
        /// <returns>节点链接对象</returns>
        private DiagramLink CreateDiagramLink(Diagram diagram, ShapeNode startNode, ShapeNode stopNode, string text = "")
        {
            var link = diagram.Factory.CreateDiagramLink(startNode, stopNode);
            link.Pen = new MindFusion.Drawing.Pen(Color.Black, 0.2f);
            link.Pen.DashStyle = DashStyle.Solid;
            link.Pen.DashPattern = new float[] { 4f, 4f };
            link.ShadowOffsetX = 0;
            link.ShadowOffsetY = 0;
            link.HandlesStyle = HandlesStyle.MoveOnly; //获取或设置链接选择句柄的外观。
            link.TextAlignment = StringAlignment.Center;//获取或设置链接的文本放置和方向。
            link.Text = text;    //获取或设置链接上显示的文本。
            link.CascadeOrientation = MindFusion.Diagramming.Orientation.Vertical; //获取或设置级联链接的第一个段的方向
            //link.HeadShape = Shapes.Donut;   //获取或设置此链接箭头的形状
            link.HeadShapeSize = 0.0f; //获取或设置箭头形状的大小。
            link.Shape = LinkShape.Spline; //获取或设置链接段的类型以及它们如何相对定位。
            return link;
        }

        /// <summary>
        /// 根据题目得分率计算出题目节点的颜色
        /// </summary>
        /// <param name="scoreRate">得分率</param>
        /// <returns></returns>
        public Color GetQuestionNodeColor(double scoreRate)
        {
            Color color;
            if (scoreRate <= 0.0)
            {
                color = _colorOfScoreRateLevel4;
            }
            else if (scoreRate <= 0.5)
            {
                color = _colorOfScoreRateLevel1;
            }
            else if (scoreRate <= 0.7)
            {
                color = _colorOfScoreRateLevel2;
            }
            else
            {
                color = _colorOfScoreRateLevel3;
            }
            return color;
        }

        /// <summary>
        /// 根据题目总分计算题目节点的宽度
        /// </summary>
        /// <param name="questionBaseScore">题目分数</param>
        /// <returns></returns>
        public int CalculateQuestionNodeWidth(int questionBaseScore)
        {
            int width;
            if (questionBaseScore <= 5 & questionBaseScore > 0)
            {
                width = 10;
            }
            else if (questionBaseScore <= 10 & questionBaseScore > 5)
            {
                width = 13;
            }
            else if (questionBaseScore > 10)
            {
                width = 16;
            }
            else
            {
                width = 10;
            }
            return width;
        }

        /// <summary>
        /// 试卷中题目节点信息
        /// </summary>
        public class ExamQuestionNodeInfo
        {
            /// <summary>
            /// 题目序号
            /// </summary>
            public int QuestionNumber { get; set; }

            /// <summary>
            /// 知识点Id
            /// </summary>
            public int KnowledgePointId { get; set; }

            /// <summary>
            /// 知识点名称
            /// </summary>
            public string KnowledgePointName { get; set; }

            /// <summary>
            /// 题目分数
            /// </summary>
            public int QuestionBaseScore { get; set; }

            /// <summary>
            /// 得分百分比[-1.0, 1.0]，如果知识点未考察，该值给负数
            /// </summary>
            public double QuestionScoreRate { get; set; }
        }

        /// <summary>
        /// 知识点描述
        /// </summary>
        public class KnowledgePointDescription
        {
            /// <summary>
            /// 知识点Id
            /// </summary>
            public int PointId { get; set; }

            /// <summary>
            /// 知识点代号
            /// </summary>
            public string PointCode { get; set; }

            /// <summary>
            /// 知识点名称
            /// </summary>
            public string PointName { get; set; }
        }
    }
}


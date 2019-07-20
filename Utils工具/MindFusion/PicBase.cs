using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace Utils工具.MyMindFusion
{
    /// <summary>
    /// 图片基类
    /// </summary>
    public class PicBase
    {
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片长度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 绘制图片所需资源
        /// </summary>
        public DrawResource DrawResources = new DrawResource();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="title">图片标题</param>
        /// <param name="width">图片长度</param>
        /// <param name="height">图片宽度</param>
        public PicBase(string title, int width, int height)
        {
            this.Title = title;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// 绘制图表标题
        /// </summary>
        /// <param name="graphics">画布</param>
        /// <param name="brush">画刷</param>
        /// <param name="stringFormat">文本布局格式</param>
        /// <param name="left">左边距</param>
        /// <param name="top">上边距</param>
        /// <param name="title">图片标题</param>
        /// <param name="font">字体大小</param>
        public virtual void CreateTitle(Graphics graphics, SolidBrush brush, StringFormat stringFormat, float left = 0f, float top = 2.5f, string title = "", Font font = null)
        {
            var rectangle = new RectangleF(-Width / 2f + left, -(Height / 2f) + top, Width, 20f);
            graphics.DrawString(title, font ?? DrawResource.Font16, brush, rectangle, stringFormat);
        }

        /// <summary>
        /// 绘制图表说明信息
        /// </summary>
        /// <param name="graphics">画布</param>
        public virtual void CreateInstructionsInfo(Graphics graphics)
        {

        }

        /// <summary>
        /// 绘制图表内容
        /// </summary>
        /// <param name="graphics">画布</param>
        public virtual void CreateContent(Graphics graphics)
        {

        }

        /// <summary>
        /// 绘制图表内容
        /// </summary>
        public virtual MemoryStream Draw()
        {
            using (var bmp = new Bitmap(Width, Height))
            {
                using (var graphics = Graphics.FromImage(bmp))
                {
                    graphics.Clear(Color.White);
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    graphics.ResetTransform();
                    graphics.TranslateTransform(Width / 2f, Height / 2f);
                    CreateTitle(graphics, DrawResources.BrushBlack, DrawResources.StringFormatCenter, 0f, 6f, this.Title, DrawResource.Font14);
                    CreateInstructionsInfo(graphics);
                    CreateContent(graphics);
                    graphics.ResetTransform();
                    graphics.Save();
                    return GetStreamFromBitmap(bmp);
                }
            }
        }

        /// <summary>
        /// 获取bitMap文件流
        /// </summary>
        /// <param name="bitmap">BitMap文件</param>
        /// <returns>MemoryStream.</returns>
        protected MemoryStream GetStreamFromBitmap(Bitmap bitmap)
        {
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            return stream;
        }
    }
}

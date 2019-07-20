using System.Drawing;
using Utils工具.ASPOSE;

namespace Miao_ToolCase.Action
{
    /// <summary>
    ///  Aspose文档操作
    /// </summary>
    public class AsposeWordShow : ShowInterface
    {
        public void Show()
        {
            //AsposeWord.NewGraphics();

            //AsposeWord.AsposeWordInsetImg();
            //AsposeWord.SetImgTwoColors();
            //SetImgTwoColors();
            //AsposeWordTable wordTable = new AsposeWordTable();
            //wordTable.AsposeWordTable1();


            //var knowledgePoint = new KnowledgePointIncreasementTableToken();
            //knowledgePoint.CreateTable();

            var writeTable = new WriteTable();
            writeTable.CreateTable();
        }

        /// <summary>
        /// 把图片替换成黑白色
        /// </summary>
        private static void SetImgTwoColors()
        {
            //AsposeWord.AsposeWordReplaceImg();
            string logoPath = "F:\\错误图片.png";
            Image image = Image.FromFile(logoPath);
            using (var bitmap = new Bitmap(image))
            {
                var images = AsposeWord.BlackWhitePhoto(bitmap);
                images.Save("E:\\BlackWhitePhoto\\错误图片.png");
            }


            //AsposeWord.BlackWhitePhoto(image);
            //var bitmap = AsposeWord.BlackWhitePhoto(image);
            //bitmap.Save("E:\\BlackWhitePhoto\\错误图片.png");
        }

        /// <summary>
        ///     提分策略模板填充类
        ///  5. 知识点提升列表：知识点名称、掌握水平、将达到水平、总分可提升、主要攻破知识点名称
        /// </summary>
        private static void KnowledgePointIncreasementTableToken()
        {


        }
    }
}

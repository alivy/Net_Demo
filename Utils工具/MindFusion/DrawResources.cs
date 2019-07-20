/*----------------------------------------------------
 * 作者: 蔡枭
 * 创建时间: 2017-03-31
 * ------------------修改记录-------------------
 * 修改人      修改日期        修改目的
 * 
 ----------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Utils工具.MyMindFusion
{
    /// <summary>
    /// 绘图资源
    /// </summary>
    public class DrawResource
    {
        #region 字体资源
        /// <summary>
        /// 12号字体（粗）
        /// </summary>
        public static Font Font12 = new Font("微软雅黑", 12f, FontStyle.Bold, GraphicsUnit.Pixel);

        /// <summary>
        /// 12号字体（规则）
        /// </summary>
        public static Font Font12R = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Pixel);

        /// <summary>
        /// 14号字体（粗）
        /// </summary>
        public static Font Font14 = new Font("微软雅黑", 14f, FontStyle.Bold, GraphicsUnit.Pixel);

        /// <summary>
        /// 16号字体（粗）
        /// </summary>
        public static Font Font16 = new Font("微软雅黑", 16f, FontStyle.Bold, GraphicsUnit.Pixel);

        /// <summary>
        /// 20号字体（粗）
        /// </summary>
        public static Font Font20 = new Font("微软雅黑", 20f, FontStyle.Bold, GraphicsUnit.Pixel);
        #endregion

        #region 颜色资源
        /// <summary>
        /// The ColorWhite.
        /// </summary>
        public static Color ColorWhite = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// The ColorBlack.
        /// </summary>
        public static Color ColorBlack = Color.FromArgb(33, 33, 33);

        /// <summary>
        /// The ColorGray.
        /// </summary>
        public static Color ColorGray = Color.FromArgb(204, 204, 204);

        /// <summary>
        /// The ColorGreen.
        /// </summary>
        public static Color ColorGreen = Color.FromArgb(0, 191, 95);

        /// <summary>
        /// The ColorRed.
        /// </summary>
        public static Color ColorRed = Color.FromArgb(255, 86, 86);

        /// <summary>
        /// The ColorLightBlue.
        /// </summary>
        public static Color ColorLightBlue = Color.FromArgb(77, 197, 255);

        /// <summary>
        /// The color blue
        /// </summary>
        public static Color ColorBlue = Color.FromArgb(25, 151, 209);

        /// <summary>
        /// The AlphaColorRed125.
        /// </summary>
        public static Color AlphaColorRed125 = Color.FromArgb(125, 255, 86, 86);

        /// <summary>
        /// The AlphaColorRed180.
        /// </summary>
        public static Color AlphaColorRed180 = Color.FromArgb(180, 255, 86, 86);

        /// <summary>
        /// The alpha color green
        /// </summary>
        public static Color AlphaColorGreen = Color.FromArgb(20, 0, 191, 95);

        /// <summary>
        /// The alpha color light blue
        /// </summary>
        public static Color AlphaColorLightBlue = Color.FromArgb(20, 77, 197, 255);

        /// <summary>
        /// The alpha color red
        /// </summary>
        public static Color AlphaColorRed = Color.FromArgb(20, 255, 86, 86);

        /// <summary>
        /// 历史得分率折线图颜色
        /// </summary>
        public static Color Blue233 = Color.FromArgb(0, 160, 233);

        /// <summary>
        /// 学科综合得分折线图颜色
        /// </summary>
        public static Color Green179 = Color.FromArgb(18, 179, 99);

        #endregion

        #region 画刷资源
        /// <summary>
        /// The BrushWhite.
        /// </summary>
        public SolidBrush BrushWhite = new SolidBrush(ColorWhite);

        /// <summary>
        /// The BrushBlack.
        /// </summary>
        public SolidBrush BrushBlack = new SolidBrush(ColorBlack);

        /// <summary>
        /// The BrushGray.
        /// </summary>
        public SolidBrush BrushGray = new SolidBrush(ColorGray);

        /// <summary>
        /// The BrushGreen.
        /// </summary>
        public SolidBrush BrushGreen = new SolidBrush(ColorGreen);

        /// <summary>
        /// The BrushRed.
        /// </summary>
        public SolidBrush BrushRed = new SolidBrush(ColorRed);

        /// <summary>
        /// The brush light red
        /// </summary>
        public SolidBrush BrushLightRed = new SolidBrush(Color.FromArgb(203, 96, 97));

        /// <summary>
        /// The BrushLightBlue.
        /// </summary>
        public SolidBrush BrushLightBlue = new SolidBrush(ColorLightBlue);

        /// <summary>
        /// The BrushLightBlue.
        /// </summary>
        public SolidBrush BrushGrayBlue = new SolidBrush(Color.FromArgb(179, 227, 227));

        /// <summary>
        /// The brush blue
        /// </summary>
        public SolidBrush BrushBlue = new SolidBrush(ColorBlue);

        /// <summary>
        /// The BrushAlphaRed180.
        /// </summary>
        public SolidBrush BrushAlphaRed180 = new SolidBrush(AlphaColorRed180);

        /// <summary>
        /// The brush right
        /// </summary>
        public SolidBrush BrushRight = new SolidBrush(Color.FromArgb(Convert.ToInt32("5B", 16), Convert.ToInt32("9B", 16), Convert.ToInt32("D5", 16)));

        /// <summary>
        /// The brush wrong
        /// </summary>
        public SolidBrush BrushWrong = new SolidBrush(Color.FromArgb(Convert.ToInt32("92", 16), Convert.ToInt32("D0", 16), Convert.ToInt32("50", 16)));

        /// <summary>
        /// The alpha brush green
        /// </summary>
        public SolidBrush AlphaBrushGreen = new SolidBrush(AlphaColorGreen);

        /// <summary>
        /// The alpha brush light blue
        /// </summary>
        public SolidBrush AlphaBrushLightBlue = new SolidBrush(AlphaColorLightBlue);

        /// <summary>
        /// The alpha brush red
        /// </summary>
        public SolidBrush AlphaBrushRed = new SolidBrush(AlphaColorRed);

        /// <summary>
        /// 得分率画刷
        /// </summary>
        public SolidBrush BrushBlue233 = new SolidBrush(Blue233);

        /// <summary>
        /// 学科综合得分画刷
        /// </summary>
        public SolidBrush BrushGreen179 = new SolidBrush(Green179);

        #endregion

        #region 画笔资源
        /// <summary>
        /// The _white.
        /// </summary>
        public Pen PenWhite = new Pen(ColorWhite, 1f);

        /// <summary>
        /// The pen white2
        /// </summary>
        public Pen PenWhite2 = new Pen(ColorWhite, 2f);

        /// <summary>
        /// The _black.
        /// </summary>
        public Pen PenBlack = new Pen(ColorBlack);

        /// <summary>
        /// The pen black dash
        /// </summary>
        public Pen PenBlackDash = new Pen(ColorBlack, 1f) { DashStyle = DashStyle.Dash, DashPattern = new[] { 3f, 1f } };

        /// <summary>
        /// The pen bold black
        /// </summary>
        public Pen PenBoldBlack = new Pen(ColorBlack, 2f);

        /// <summary>
        /// The pen gray
        /// </summary>
        public Pen PenGray = new Pen(ColorGray, 1f);

        /// <summary>
        /// The pen gray bold
        /// </summary>
        public Pen PenGrayBold = new Pen(ColorGray, 12f);

        /// <summary>
        /// The _green.
        /// </summary>
        public Pen PenGreen = new Pen(ColorGreen);

        /// <summary>
        /// The pen green bold
        /// </summary>
        public Pen PenGreenBold = new Pen(ColorGreen, 10f);

        /// <summary>
        /// The _red 1.
        /// </summary>
        public Pen PenRed = new Pen(ColorRed);

        /// <summary>
        /// The pen red bold
        /// </summary>
        public Pen PenRedBold = new Pen(ColorRed, 10f);

        /// <summary>
        /// The BrushLightBlue.
        /// </summary>
        public Pen PenLightBlue = new Pen(ColorLightBlue);

        /// <summary>
        /// The pen alpha red180 dot
        /// </summary>
        public Pen PenAlphaRed180Dot = new Pen(AlphaColorRed180, 2f) { DashStyle = DashStyle.Dot };

        /// <summary>
        /// The pen alpha red180 solid
        /// </summary>
        public Pen PenAlphaRed180 = new Pen(AlphaColorRed180, 1f) { DashStyle = DashStyle.Solid };

        /// <summary>
        /// 绘制历史得分率折线画笔
        /// </summary>
        public Pen PenBlueDash = new Pen(Blue233, 2f) { DashStyle = DashStyle.Dash, DashPattern = new[] { 3f, 1f } };

        /// <summary>
        /// 绘制学科综合得分折线画笔
        /// </summary>
        public Pen PenGreenSolid = new Pen(Green179, 2f) { DashStyle = DashStyle.Solid };

        #endregion

        #region 文本布局
        /// <summary>
        /// The string format far
        /// </summary>
        public StringFormat StringFormatFar = new StringFormat() { Alignment = StringAlignment.Far };

        /// <summary>
        /// The string format far center
        /// </summary>
        public StringFormat StringFormatFarCenter = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

        /// <summary>
        /// The string format center
        /// </summary>
        public StringFormat StringFormatCenter = new StringFormat() { Alignment = StringAlignment.Center };

        /// <summary>
        /// The string format center middle
        /// </summary>
        public StringFormat StringFormatCenterMiddle = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        /// <summary>
        /// The string format near
        /// </summary>
        public StringFormat StringFormatNear = new StringFormat() { Alignment = StringAlignment.Near };
        #endregion

        #region 知识点掌握水平提升图
        /// <summary>
        /// 成绩等级对应填充颜色
        /// </summary>
        public Dictionary<int, SolidBrush[]> RankColor = new Dictionary<int, SolidBrush[]>()
                                                                    {
                                                                        {1,new[]{new SolidBrush(ColorRed),new SolidBrush(AlphaColorRed)}},
                                                                        {2,new[]{ new SolidBrush(ColorLightBlue),new SolidBrush(AlphaColorLightBlue)}},
                                                                        {3,new[]{new SolidBrush(ColorGreen),new SolidBrush(AlphaColorGreen)}}
                                                                    };

        /// <summary>
        /// 不同成绩等级对应的区域虚线颜色
        /// </summary>
        public Dictionary<int, Pen> RankPens = new Dictionary<int, Pen>()
                                                               {
                                                                   {1,new Pen(ColorRed){DashStyle = DashStyle.Solid}},
                                                                   {2,new Pen(ColorLightBlue){DashStyle = DashStyle.Solid}},
                                                                   {3,new Pen(ColorGreen){DashStyle = DashStyle.Solid}}
                                                               };

        /// <summary>
        /// 不同成绩等级对应的区域实线颜色
        /// </summary>
        public Dictionary<int, Pen> RankDashPens = new Dictionary<int, Pen>()
                                                               {
                                                                   {1,new Pen(ColorRed){DashStyle = DashStyle.Dash,DashPattern = new[] { 6f, 3f }}},
                                                                   {2,new Pen(ColorLightBlue){DashStyle = DashStyle.Dash,DashPattern = new[] { 6f, 3f }}},
                                                                   {3,new Pen(ColorGreen){DashStyle = DashStyle.Dash,DashPattern = new[] { 6f, 3f }}}
                                                               };
        #endregion

        #region 知识点分数占比图
        /// <summary>
        /// 颜色资源
        /// </summary>
        public List<Color> Colors = new List<Color>()
                                                    {
                                                        Color.FromArgb(Convert.ToInt32("2E",16),Convert.ToInt32("C7",16),Convert.ToInt32("C9",16)),
                                                        Color.FromArgb(Convert.ToInt32("B6",16),Convert.ToInt32("A2",16),Convert.ToInt32("DE",16)),
                                                        Color.FromArgb(Convert.ToInt32("5A",16),Convert.ToInt32("B1",16),Convert.ToInt32("EF",16)),
                                                        Color.FromArgb(Convert.ToInt32("FF",16),Convert.ToInt32("B9",16),Convert.ToInt32("80",16)),
                                                        Color.FromArgb(Convert.ToInt32("D8",16),Convert.ToInt32("7A",16),Convert.ToInt32("80",16)),
                                                        Color.FromArgb(Convert.ToInt32("5A",16),Convert.ToInt32("B1",16),Convert.ToInt32("EF",16)),
                                                        Color.FromArgb(Convert.ToInt32("2E",16),Convert.ToInt32("C7",16),Convert.ToInt32("C9",16)),
                                                        Color.FromArgb(Convert.ToInt32("FF",16),Convert.ToInt32("B9",16),Convert.ToInt32("80",16)),
                                                        Color.FromArgb(Convert.ToInt32("D8",16),Convert.ToInt32("7A",16),Convert.ToInt32("80",16)),
                                                        Color.FromArgb(Convert.ToInt32("B6",16),Convert.ToInt32("A2",16),Convert.ToInt32("DE",16))
                                                    };
        #endregion

        /// <summary>
        /// 知识点掌握水平占比颜色
        /// </summary>
        public Dictionary<string, Color> KpLevelPercentageColors = new Dictionary<string, Color>
        {
            {"0%~25%",Color.FromArgb(237,125,49)}, {"25%~50%",Color.FromArgb(90,151,206)},                                                                        
            {"50%~75%",Color.FromArgb(165,165,165)}, {"75%~100%",Color.FromArgb(255,192,0)}
        };
    }
}
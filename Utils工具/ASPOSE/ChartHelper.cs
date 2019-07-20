using Aspose.Words.Tables;
using RuanYun.Word.Builder.GridData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils工具.ASPOSE
{
    public class ChartHelper
    {
        /// <summary>
        /// 表格通用设置，包括字体类型、大小、颜色
        /// </summary>
        public static void TableCommonSetting(GridTable tb)
        {
            if (tb == null) return;
            tb.DefaultFontName = "微软雅黑";
            tb.DefaultFontSize = 10.5;
            tb.DefaultForegroundColor = GetRgb("#333");
            tb.DefaultCellAlign = CellAlign.Center;
            tb.DefaultBorderColor = Color.LightGray;
            tb.TablePreferredWidth = PreferredWidth.FromPercent(100);
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

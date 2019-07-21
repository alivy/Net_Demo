using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelForm.Exporter.From
{
    public partial class ExporterExcel : Form
    {
        public ExporterExcel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exl03_Click(object sender, EventArgs e)
        {
            Exporter.Instance().Download();
            var title = "[[{\"field\":\"BillNo\",\"align\":\"left\",\"sortable\":true,\"width\":90,\"title\":\"收料单号   \",\"boxWidth\":82,\"cellClass\":\"datagrid - cell - c1 - BillNo\",\"cellSelector\":\"div.datagrid - cell - c1 - BillNo\"},{\"field\":\"SupplierName\",\"align\":\"left\",\"sortable\":true,\"width\":200,\"title\":\"供应商     \",\"boxWidth\":192,\"cellClass\":\"datagrid - cell - c1 - SupplierName\",\"cellSelector\":\"div.datagrid - cell - c1 - SupplierName\"},{\"field\":\"SupplyType\",\"align\":\"center\",\"sortable\":true,\"width\":70,\"title\":\"供应类型   \",\"boxWidth\":62,\"cellClass\":\"datagrid - cell - c1 - SupplyType\",\"cellSelector\":\"div.datagrid - cell - c1 - SupplyType\"},{\"field\":\"ContractCode\",\"align\":\"left\",\"sortable\":true,\"width\":100,\"title\":\"合同名称   \",\"boxWidth\":92,\"cellClass\":\"datagrid - cell - c1 - ContractCode\",\"cellSelector\":\"div.datagrid - cell - c1 - ContractCode\"},{\"field\":\"WarehouseName\",\"align\":\"left\",\"sortable\":true,\"width\":100,\"title\":\"库房       \",\"boxWidth\":92,\"cellClass\":\"datagrid - cell - c1 - WarehouseName\",\"cellSelector\":\"div.datagrid - cell - c1 - WarehouseName\"},{\"field\":\"ReceiveDate\",\"align\":\"center\",\"sortable\":true,\"width\":80,\"title\":\"收料日期   \",\"boxWidth\":72,\"cellClass\":\"datagrid - cell - c1 - ReceiveDate\",\"cellSelector\":\"div.datagrid - cell - c1 - ReceiveDate\"},{\"field\":\"TotalMoney\",\"align\":\"right\",\"sortable\":true,\"width\":70,\"title\":\"金额       \",\"boxWidth\":62,\"cellClass\":\"datagrid - cell - c1 - TotalMoney\",\"cellSelector\":\"div.datagrid - cell - c1 - TotalMoney\"},{\"field\":\"OriginalNum\",\"align\":\"left\",\"sortable\":true,\"width\":90,\"title\":\"原始票号   \",\"boxWidth\":82,\"cellClass\":\"datagrid - cell - c1 - OriginalNum\",\"cellSelector\":\"div.datagrid - cell - c1 - OriginalNum\"},{\"field\":\"DoPerson\",\"align\":\"left\",\"sortable\":true,\"width\":60,\"title\":\"经办人     \",\"boxWidth\":52,\"cellClass\":\"datagrid - cell - c1 - DoPerson\",\"cellSelector\":\"div.datagrid - cell - c1 - DoPerson\"},{\"field\":\"Remark\",\"align\":\"left\",\"sortable\":true,\"width\":150,\"title\":\"备注       \",\"boxWidth\":142,\"cellClass\":\"datagrid - cell - c1 - Remark\",\"cellSelector\":\"div.datagrid - cell - c1 - Remark\"}]]";
            var dataParams = "'{ \"BillNo\":\"\",\"SupplierName\":\"\",\"SupplyType\":\"\",\"WarehouseCode\":\"\",\"ContractCode\":\"\",\"ReceiveDate\":\"\"}";
            var dataGetter = "api";
            var fileType = "xlsx";
            var compressType = "none";
        }
    }
}

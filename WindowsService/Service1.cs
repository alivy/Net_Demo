using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Utils工具;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {

        Timer timer1;  //计时器
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            seviceStart();
        }

        protected override void OnStop()
        {
            //服务停止执行
            this.timer1.Enabled = false;
        }


        private void seviceStart()
        {
            timer1 = new Timer();
            timer1.Interval = 3000;  //设置计时器事件间隔执行时间
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件； 
            timer1.AutoReset = true;//设置是执行一次（false）还是一直执行(true)； 
        }

        //执行任务操作
        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            string strTest = string.Format(DateTime.Now.ToString() + "执行服务成功");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\\test2.txt", true))
            {
                file.WriteLine(strTest);// 直接追加文件末尾，换行 
            }
        }
    }
}

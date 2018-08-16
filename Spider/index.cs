using Spider.Log;
using Spider.Page;
using Spider.Spider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider
{
    public partial class index : Form
    {
     
        public index()
        {
            InitializeComponent();
            Common.CommonFunc cf = new Common.CommonFunc();
            cf.InitialFunc();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            #region 日志文件记录
            ClsLog clsLog = new ClsLog();
            Thread LogThread = new Thread(new ThreadStart(clsLog.WriteLog));
            LogThread.Start();
            #endregion

            #region 抓取线程
            clsLog.AddLog(DateTime.Now.ToString(), "抓取开始");
            ClsPageUrl clsPageUrl = new ClsPageUrl();
            Thread SpiderThread = new Thread(new ThreadStart(clsPageUrl.SpiderData));
            SpiderThread.Start();
            #endregion

            #region 分析线程
            ClsPageContent clsPageContent = new ClsPageContent();
            Thread AnalyseThread = new Thread(new ThreadStart(clsPageContent.AnalyseData));
            AnalyseThread.Start();
            #endregion

            #region 数据库插入操作线程
            //ClsDB clsDB = new ClsDB();
            //Thread dbThread = new Thread(new ThreadStart(clsDB.ExecPageDBData));
            //dbThread.Start();
            #endregion

            #region 事件注册
            EventController helper = new EventController();
            /// 所有需要分析的，都完成事件
            helper.OnAllItemAnalyzeCompleted += (senders, es) =>
            {
                if (Program.clsUrlSignal == 0 && Program.clsContentSignal == 0 && Program.clsDBSignal == 0)
                {
                    SpiderThread.Abort();
                    AnalyseThread.Abort();
                    //dbThread.Abort();
                    Thread.Sleep(20000);
                    LogThread.Abort();
                    clsLog.AddLog(DateTime.Now.ToString(), "抓取结束");
                }

            };

            #endregion

            //入口方法
            spiderMain();




        }

        public void spiderMain()
        {
            ClsLog clsLog = new ClsLog();
            clsLog.AddLog(DateTime.Now.ToString(), "入口抓取开始");
            bool flag = false;
            int CurrSpiderTimes = 1;
            ClsPageUrl clsPageUrl = new ClsPageUrl();

            Control.CheckForIllegalCrossThreadCalls = false;

            clsPageUrl.AddPageUrl("ProgramName", "", "", "Portal", "", "", "http://cht.cjsyw.com:8080/ShipSource/listSS.aspx?pageno=1",
            "GET", "", "utf-8","", null, "", 1, 1);


        }



    }
}

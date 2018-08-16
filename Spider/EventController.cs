using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider
{
    public class EventController
    {


        /// <summary>
        /// 抓取完成事件
        /// </summary>
        public event EventHandler<EventControllerArgs> OnSpiderDataCompletedEvent;

        /// <summary>
        /// 分析完成时间
        /// </summary>
        public event EventHandler<EventControllerArgs> OnAnalyseDataCompletedEvent;

        /// <summary>
        /// 插入完成时间
        /// </summary>
        public event EventHandler<EventControllerArgs> OnExecPageDBDataCompletedEvent;

        /// <summary>
        /// 所有需要分析的，都完成事件
        /// </summary>
        public event EventHandler<EventControllerArgs> OnAllItemAnalyzeCompletedEvent;


        /// <summary>
        /// 列表页集合
        /// </summary>

        public EventHandler<EventControllerArgs> OnSpiderDataCompleted;
        public EventHandler<EventControllerArgs> OnAnalyseDataCompleted;
        public EventHandler<EventControllerArgs> OnExecPageDBDataCompleted;
        public EventHandler<EventControllerArgs> OnAllItemAnalyzeCompleted;
        public EventController()
        {

            OnSpiderDataCompleted = OnSpiderDataCompletedEvent;
            OnAnalyseDataCompleted = OnAnalyseDataCompletedEvent;
            OnExecPageDBDataCompleted = OnAnalyseDataCompletedEvent;
            OnAllItemAnalyzeCompleted = OnAllItemAnalyzeCompletedEvent;
        }

        /// <summary>
        /// 分析事件参数
        /// </summary>
        public class EventControllerArgs : EventArgs
        {
            public EventControllerArgs()
            {
                Total = 0;
                IsSuccess = true;
            }
            public bool IsSuccess { get; set; }
            public object Data { get; set; }
            public int Total { get; set; }
        }

    }
}

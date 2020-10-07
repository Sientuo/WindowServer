using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowBLL;
using WindowShare;

namespace WindowServer.Buess
{
    public class TopBuess
    {

        private Timer timer1 = null;
        private Timer timer2 = null;

        public TopBuess()
        {
            LogHelper.WriteInfo("开始执行...");
            var temp = ConfigHelper.GetCacheValue("PrduQueueOnceTime").ToStr();
            var temd = ConfigHelper.GetCacheValue("DealQueueOnceTime").ToStr();
            var ps = temp == "" ? 6000 : int.Parse(temp);
            var ds = temd == "" ? 5000 : int.Parse(temd);
            //执行定时服务
            timer1 = new Timer() { AutoReset = true, Enabled = true, Interval = ps };
            timer1.Elapsed += (sender, eventArgs) => TaskQueue.WriteQueue(timer1);

            timer2 = new Timer() { AutoReset = true, Enabled = true, Interval = ds };
            timer2.Elapsed += (sender, eventArgs) => TaskQueue.OutQueue(timer2);
        }

        //写入数据
        public void Start() { timer1.Start(); timer2.Start(); }
        public void Stop() { timer1.Stop(); timer2.Stop(); }
    }
}

using Autofac;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowBLL;
using WindowIBLL;
using WindowModel.EntityModel;
using WindowModel.ViewModel;
using WindowShare;

namespace WindowServer.Buess
{
    class TaskQueue
    {
        //任务队列
        public static ConcurrentQueue<KiaserTask> PrduQueue = new ConcurrentQueue<KiaserTask>();

        //入队
        public static void WriteQueue(Timer timer)
        {
            LogHelper.WriteInfo("当前入队时间:"+DateTime.Now.ToString("yyyyMMdd hh:mm:ss"));
            timer.Stop();
            try
            {
                //查询任务表
                var container = ContainerHelper.GetContainer();
                var manager = container.Resolve<IKiaserTaskBLL>();//通过resolve方法取得对象
                var kiasers = manager.GetKiaserTasks();
                foreach (var item in kiasers)
                {
                    PrduQueue.Enqueue(item);
                    manager.Delete(item.ID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message);
            }
             timer.Start();
        }


        //出队
        public static void OutQueue(Timer timer)
        {
            LogHelper.WriteInfo("当前出队时间:" + DateTime.Now.ToString("yyyyMMdd hh:mm:ss"));
            timer.Stop();
            try
            {
                while (!PrduQueue.IsEmpty)
                {
                    PrduQueue.TryDequeue(out KiaserTask kiaser);
                    //写入学校表
                    var container = ContainerHelper.GetContainer();
                    var manager = container.Resolve<ISchooBLL>();//通过resolve方法取得对象
                    var model = new EIC_School
                    {
                        ID = Guid.NewGuid().ToString(),
                        SchoolCode = kiaser.SchoolCode,
                        SchoolName = kiaser.SchoolName
                    };
                    var kiasers = manager.Add(model);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message);
            }
            timer.Start();
        }
    }
}

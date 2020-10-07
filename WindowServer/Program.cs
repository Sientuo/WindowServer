using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Topshelf;
using WindowBLL;
using WindowModel.EntityModel;
using WindowServer.Buess;
using WindowShare;

namespace WindowServer
{
    class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormInit());

            HostFactory.Run(x =>
            {
                x.Service<TopBuess>(s =>
                {
                    s.ConstructUsing(name =>new TopBuess());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("该服务定时写入数据库数据");
                x.SetDisplayName("数据管理服务端");
                x.SetServiceName("数据管理服务");
            });
            Console.ReadKey();
        }
    }
}

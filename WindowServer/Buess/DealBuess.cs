using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowBLL;
using WindowModel.EntityModel;
using WindowShare;

namespace WindowServer.Buess
{
    public class DealBuess
    {

        //查询一笔学生数据
        public static string GetOneDataById()
        {
            var Builder = ContainerHelper.GetContainer();
            var manager = Builder.Resolve<ISchooBLL>();//通过resolve方法取得对象
            var temp = manager.GetOneDataById("a6409499-a5d7-4108-96ad-15ff2a2f884a");
            return temp.SchoolName;
        }

        //写入一笔数据
        public static void AddOneData()
        {
            try
            {
                var Builder = ContainerHelper.GetContainer();
                var manager = Builder.Resolve<ISchooBLL>();//通过resolve方法取得对象
                var list = new List<EIC_School>();
                var temp = DateTime.Now.ToString("yyyyMMddhhmmss");
                var model = new EIC_School
                {
                    ID = Guid.NewGuid().ToString(),
                    SchoolCode = temp,
                    SchoolName = "木叶第" + temp + "小学"
                };
                manager.Add(list);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message);
            }
        }
    }
}

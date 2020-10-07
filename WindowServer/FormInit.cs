using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBLL;
using WindowModel.EntityModel;
using WindowShare;

namespace WindowServer
{
    public partial class FormInit : Form
    {
        public FormInit()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var Builder =  ContainerHelper.GetContainer();
            var manager = Builder.Resolve<ISchooBLL>();//通过resolve方法取得对象
            var list = new List<EIC_School>();
            for (int i = 0; i < 10000; i++)
            {
                var model = new EIC_School
                {
                    ID = Guid.NewGuid().ToString(),
                    SchoolCode = "XX100000" + i,
                    SchoolName = "木叶第" + i + "小学"
                };
                list.Add(model);
            }
            var temp = manager.Add(list);
            MessageBox.Show(temp.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Builder = ContainerHelper.GetContainer();
            var manager = Builder.Resolve<ISchooBLL>();//通过resolve方法取得对象
            var temp = manager.MySelf();
            MessageBox.Show(temp.ToString());
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            var Builder = ContainerHelper.GetContainer();
            var manager = Builder.Resolve<ISchooBLL>();//通过resolve方法取得对象
            var temp = manager.GetOneDataById("a6409499-a5d7-4108-96ad-15ff2a2f884a");
            MessageBox.Show(temp.SchoolName);
        }

        private void BtnUpdateTime_Click(object sender, EventArgs e)
        {
            var Builder = ContainerHelper.GetContainer();
            var manager = Builder.Resolve<ISchooBLL>();//通过resolve方法取得对象
            var temp = manager.UpdateTime(DateTime.Now);
            var mess = temp > 0 ? "更新成功" : "更新失败";
            MessageBox.Show(mess);
        }
    }


}

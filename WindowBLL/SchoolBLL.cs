using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowIBLL;
using WindowIDLL;
using WindowModel.EntityModel;

namespace WindowBLL
{
    public class SchoolBLL : BaseBLL,ISchooBLL
    {
        ISchoolDLL SchDLL { get; set; }

        public SchoolBLL(ISchoolDLL dLL)
        {
            //BaseDLL = dLL;
            SchDLL = dLL;
        }

        public string MySelf()
        {
            return "这是一个笑话";
        }

        public int Add(object param)
        {
          return  SchDLL.Add(param);
        }

        public int Test()
        {
            return 3000;
        }

        public int DeleteById(string strsql, object param)
        {
            throw new NotImplementedException();
        }

        public EIC_School GetOneDataById(string id)
        {
            return SchDLL.GetOneDataById(id);
        }

        public int UpdateTime(object param)
        {
            return SchDLL.UpdateTime(param);
        }
    }
}

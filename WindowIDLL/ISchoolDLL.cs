using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowModel.EntityModel;

namespace WindowIDLL
{
    public interface ISchoolDLL:IBaseDLL
    {
        int Add(object param);

        int UpdateTime(object param);

        //查询一笔数据
       EIC_School GetOneDataById(string id);
    }
}

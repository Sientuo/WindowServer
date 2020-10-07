using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowModel.ViewModel;

namespace WindowIBLL
{
    public interface IKiaserTaskBLL:IBaseBLL
    {

        List<KiaserTask> GetKiaserTasks();

        int Delete(string id);
    }
}

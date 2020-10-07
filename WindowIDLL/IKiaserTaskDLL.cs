using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowModel.ViewModel;

namespace WindowIDLL
{
    public interface IKiaserTaskDLL: IBaseDLL
    {
        List<KiaserTask> GetKiaserTasks();

        int Delete(string id);
    }
}

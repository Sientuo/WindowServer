using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowIBLL;
using WindowIDLL;
using WindowModel.ViewModel;

namespace WindowBLL
{
    public class KiaserTaskBLL : BaseBLL, IKiaserTaskBLL
    {

        IKiaserTaskDLL KiaDLL { get; set; }

        public KiaserTaskBLL(IKiaserTaskDLL dLL)
        {
            //BaseDLL = dLL;
            KiaDLL = dLL;
        }
        public int Delete(string id)
        {
            return KiaDLL.Delete(id);
        }

        public List<KiaserTask> GetKiaserTasks()
        {
            return KiaDLL.GetKiaserTasks();
        }
    }
}

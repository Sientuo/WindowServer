using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowIDLL;
using WindowModel.ViewModel;
using WindowShare;

namespace WindowDLL
{
    class KiaserTaskDLL : IKiaserTaskDLL
    {
        public int Delete(string id)
        {
            var strsql = new StringBuilder();
            strsql.Append(" Delete From KiaserTask Where ID =@ID ");
             var parameters = new DynamicParameters();
            parameters.Add("@ID", id);
            return DapperHelper<KiaserTask>.Execute(strsql.ToString(), parameters);
        }

        public List<KiaserTask> GetKiaserTasks()
        {
            var strsql = new StringBuilder();
            strsql.Append(" Select ID,SchoolCode,SchoolName,CreateDate from KiaserTask Order by CreateDate");
            return DapperHelper<KiaserTask>.Query(strsql.ToString(), null);
        }
    }
}

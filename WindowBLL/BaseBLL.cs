using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowIBLL;
using WindowIDLL;

namespace WindowBLL
{
    public class BaseBLL : IBaseBLL
    {
        protected IBaseDLL BaseDLL = null;

    }
}

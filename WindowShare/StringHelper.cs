using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowShare
{
   public static  class StringHelper
    {
        public static string ToStr(this object obj)
        {
            var res = obj as string;
            return res ?? string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowShare
{
    public class ConfigHelper
    {
        //取值-写值
        public static object GetInitValue(string key)
        {
            Dictionary<string, string> des = new Dictionary<string, string>();
            try
            {
                var obj = new object();
                lock (obj)
                {
                    var exePath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                    string Path = exePath + "Config" + "\\KiaConfig.xml";
                    XElement root = XElement.Load(Path);
                    var quests = from c in root.Elements() select c;
                    foreach (var item in quests)
                    {
                        //des.Add(item.Name.LocalName, item.Value);
                        CacheHelper.SetCache(item.Name.LocalName, item.Value);
                    }
                    return CacheHelper.GetCache(key);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "--" + ex.StackTrace);
                return null;
            }
        }

        //Cache赋值-内存
        public static void SetConfigValue(Dictionary<string, string> dic)
        {
            try
            {
                //映射成员字段//PropertyInfo[] propertyInfos =GetType().GetProperties();
                foreach (var item in dic)
                {
                    //item.SetValue(this, dic[item.Name]);  --遍历
                    CacheHelper.SetCache(item.Key, item.Value);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "---" + ex.StackTrace);
            }
        }


        //判断-内存是否有值
        public static object GetCacheValue(string key)
        {
            return CacheHelper.GetCache(key) ?? GetInitValue(key);
        }

    }
}

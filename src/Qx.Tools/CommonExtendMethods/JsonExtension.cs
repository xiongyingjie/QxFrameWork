using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Qx.Tools.CommonExtendMethods
{
   public static class JsonExtension
    {
       public static string Serialize<T>(this T obj)
       {
           return JsonUtility.Serialize(obj);
       }
       public static T Deserialize<T>(this string jsonString)
       {
           return JsonUtility.Deserialize<T>(jsonString);
       }
    }
}

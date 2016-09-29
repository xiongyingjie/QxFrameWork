using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Test;
using Qx.Tools.Ioc.Unity;

namespace Qx
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityIoc.Register(new List<Type>()
            {
                typeof(Test.Report.Test),
                typeof(RunTest)
            });

        }
    }
}

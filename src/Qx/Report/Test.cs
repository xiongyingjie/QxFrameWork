using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Qx.Report.Interfaces;

namespace Qx.Test.Report
{
    public class Test : ITest
    {
       private readonly IReportServices _reportServices;

       public Test(IReportServices reportServices)
       {
           _reportServices = reportServices;
       }

       private const string Connstr_SCSXXT_DEV =
           "Data Source=SCSXXT.COM;Initial Catalog=SCSXXT_DEV;Persist Security Info=True;User ID=sa;Password=Hqu33333;MultipleActiveResultSets=true";
       private const string Connstr_Qx_Permission =
         "Data Source=SCSXXT.COM;Initial Catalog=Qx.Permission;Persist Security Info=True;User ID=sa;Password=Hqu33333;MultipleActiveResultSets=True;MultipleActiveResultSets=true";
     
       public void Do()
       {
         var result=  _reportServices.ToHtml("System", ";", Connstr_SCSXXT_DEV);
           result.Reverse();
       }
   }
}

using System.Collections.Generic;

namespace Qx.Report.Interfaces
{
    public interface IReportServices
    {
        bool Add(Models.Report model);
        bool Update(Models.Report model);
        bool Delete(string id);
        Models.Report GetReprot(string id);
        string ToExcel(string id, string parms, string templateFileDir, string outputFileDir,string dbConnStringKey);
        List<List<string>> ToHtml(string id, string parms, string dbConnStringKey);
   }
}

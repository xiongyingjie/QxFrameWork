using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Qx.Contents.Models;

namespace Qx.Contents.Interfaces
{
   public interface IContents
   {
       TableDesign GetTableDesign(string tableId);
       TableValue GetTableValue(string tableId, string relationKeyId);
       bool UpdateTable(ContentBag contentValueBag);
       bool UpdateTable(HttpRequestBase request, string tableId, string relationKeyId);
    }
}

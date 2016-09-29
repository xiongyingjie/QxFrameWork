using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Mvc.Html;

namespace Qx.Contents.Services
{
    public static class ContentsExtension
    {
        public const string SAVE_DIR = "/UserFiles/Contents";
        public static MvcHtmlString ContentsFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
             Expression<Func<TModel, TProperty>> expression, string tipString)
        {
            var tableId = htmlHelper.DisplayFor(expression).ToString();

            if (!tableId.HasValue())
            {
                throw new Exception("请检查ViewModel中是否给"+ htmlHelper.IdFor(expression)+"赋值");
            }
            //获取Table信息
            var service=new ContentService();
            var table = service.GetTableDesign(tableId);
            
            var dest = new StringBuilder();
            //判断控件类型
            table.Columns.ToList().ForEach(t =>
            {
                switch (t.DateTypeID)
                {
                    case "file":
                    {
                        dest.Append(htmlHelper.File(t.ColumnName, t.ColumnID, t.ColumnID, SAVE_DIR, "请上传" + t.ColumnName));
                     }
                        break;
                    case "DateTime":
                        {
                            dest.Append(htmlHelper.TimeFor(expression, tipString));
                        }
                        break;

                    default :
                        dest.Append(htmlHelper.InputFor(expression, tipString));break;

                }
            });
          
            return new MvcHtmlString(dest.ToString());
        }


        public static bool UpdateTable(this HttpRequestBase request, string tableId, string relationKeyId)
        {
            var service = new ContentService();
            return service.UpdateTable(request, tableId, relationKeyId);
        }
    }
}

using System;
using Web.Controllers.Base;

namespace Web.Areas.Permission.Controllers
{
    public class BasePermissionController : BaseAccountController
    {
        protected void InitReport(string Title, string AddLink, int pageIndex, int perCount, string ExtraParam = "", bool showDeafultButton = true)
        {
            base.InitReport(Title, AddLink, pageIndex, perCount, ExtraParam,showDeafultButton, "Qx.Permission");
        }

        protected string BackToReport
        {
            get
            {
                return "该属性已禁用";
            }
           
    }
    }
}

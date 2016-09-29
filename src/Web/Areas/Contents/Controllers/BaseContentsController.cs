using Web.Controllers.Base;

namespace Web.Areas.Contents.Controllers
{
    public abstract class BaseContentsController : BaseAccountController
    {
        protected void InitReport(string Title, string AddLink, int pageIndex, int perCount, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, pageIndex, perCount, ExtraParam, showDeafultButton, "Qx.Contents");
        }
    }
}
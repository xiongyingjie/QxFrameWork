using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class BanButtonList_M
    {
        public static BanButtonList_M ToViewModel(Role role)
        {
            return new BanButtonList_M() { role = role };
        }
        public Role role;
    }
}
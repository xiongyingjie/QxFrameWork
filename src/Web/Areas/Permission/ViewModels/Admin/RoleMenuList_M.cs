using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class RoleMenuList_M
    {
        public static RoleMenuList_M ToViewModel(Role role)
        {
            return new RoleMenuList_M() { role = role };
        }
        public Role role;
    }
}
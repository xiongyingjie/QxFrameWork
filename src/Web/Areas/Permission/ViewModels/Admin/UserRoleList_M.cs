using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class UserRoleList_M
    {
        public static UserRoleList_M ToViewModel(User user)
        {
            return new UserRoleList_M() {user=user };
        }
        public User user;
    }
}
using System.Collections.Generic;
using Qx.Permission.Entity;

namespace Web.Areas.Permission.ViewModels.Admin
{
    public class MenuList_M
    {
        public static MenuList_M ToViewModel(List<Menu> fathers)
        {
            return new MenuList_M() { fathers = fathers };
        }
        public List<Menu> fathers;
    }
}
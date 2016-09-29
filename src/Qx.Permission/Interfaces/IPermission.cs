using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Permission.Models;

namespace Qx.Permission.Interfaces
{
    public interface IPermission
    {
        List<MenuItem>  GetMenuByUserId(string userId);
        List<Button> GetForbidenButtonByUserId(string userId);
        List<SelectListItem> GetMenu(string selectedMenuId = "-1", string rootFather = "MRoot");
        List<Menu> FindFather(string menuid);
    }
}
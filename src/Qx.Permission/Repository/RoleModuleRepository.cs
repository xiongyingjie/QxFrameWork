using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class RoleMenuRepository : BaseRepository, IRepository<RoleMenu>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(RoleMenu model)
        {
            return Db.SaveAdd(model) ? model.RoleMenuID : null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(RoleMenu model, string note = "")
        {
            throw new System.NotImplementedException();
        }

        public RoleMenu Find(object id)
        {
            return Db.RoleMenus.Find(id);
        }

        public System.Collections.Generic.List<RoleMenu> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<RoleMenu> All(System.Func<RoleMenu, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public RoleMenu Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

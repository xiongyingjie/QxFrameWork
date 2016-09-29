using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class RoleRepository : BaseRepository, IRepository<Role>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(Role model)
        {
            return Db.SaveAdd(model)?model.RoleID:null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(Role model, string note = "")
        {
            throw new System.NotImplementedException();
        }

        public Role Find(object id)
        {
            return Db.Roles.Find(id);
        }

        public System.Collections.Generic.List<Role> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Role> All(System.Func<Role, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public Role Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

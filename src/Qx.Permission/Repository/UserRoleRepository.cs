using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class UserRoleRepository : BaseRepository, IRepository<UserRole>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(UserRole model)
        {
            return Db.SaveAdd(model) ? model.UserRoleID : null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(UserRole model, string note = "")
        {
            throw new System.NotImplementedException();
        }

        public UserRole Find(object id)
        {
            return Db.UserRoles.Find(id);
        }

        public System.Collections.Generic.List<UserRole> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<UserRole> All(System.Func<UserRole, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public UserRole Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

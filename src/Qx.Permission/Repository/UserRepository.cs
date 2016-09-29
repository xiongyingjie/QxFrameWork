using System.Linq;
using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class UserRepository : BaseRepository, IRepository<User>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(User model)
        {
            return Db.SaveAdd(model) ? model.UserID : null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(User model, string note = "")
        {
            throw new System.NotImplementedException();
        }

        public User Find(object id)
        {
            return Db.Users.Find(id);
        }

        public System.Collections.Generic.List<User> All()
        {
            return Db.Users.ToList();
        }

        public System.Collections.Generic.List<User> All(System.Func<User, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public User Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

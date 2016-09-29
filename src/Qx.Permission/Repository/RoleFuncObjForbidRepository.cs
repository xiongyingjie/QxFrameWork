using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class RoleButtonForbidRepository : BaseRepository, IRepository<RoleButtonForbid>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(RoleButtonForbid model)
        {
            return Db.SaveAdd(model)?model.RoleButtonForbidID:null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(RoleButtonForbid model, string note = "")
        {
            throw new System.NotImplementedException();
        }

        public RoleButtonForbid Find(object id)
        {
            return Db.RoleButtonForbids.Find(id);
        }

        public System.Collections.Generic.List<RoleButtonForbid> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<RoleButtonForbid> All(System.Func<RoleButtonForbid, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public RoleButtonForbid Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

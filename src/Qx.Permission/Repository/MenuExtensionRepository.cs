using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class MenuExtensionRepository : BaseRepository, IRepository<MenuExtension>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(MenuExtension model)
        {
           
            return Db.SaveAdd(model) ? model.MenuID : null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(MenuExtension model, string note = "")
        {
            return Db.SaveModified(model);
        }

        public MenuExtension Find(object id)
        {
            return Db.MenuExtensions.Find(id);
        }

        public System.Collections.Generic.List<MenuExtension> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<MenuExtension> All(System.Func<MenuExtension, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public MenuExtension Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class MenuRepository : BaseRepository, IRepository<Menu>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(Menu model)
        {
           
            return Db.SaveAdd(model) ? model.MenuID : null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(Menu model, string note = "")
        {
            return Db.SaveModified(model);
        }

        public Menu Find(object id)
        {
            return Db.Menus.Find(id);
        }

        public System.Collections.Generic.List<Menu> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Menu> All(System.Func<Menu, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public Menu Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

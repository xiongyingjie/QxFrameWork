using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Permission.Services;
using Qx.Tools.Interfaces;

namespace Qx.Permission.Repository
{


    public class ButtonRepository : BaseRepository, IRepository<Button>
    {

        public System.Collections.Generic.List<System.Web.Mvc.SelectListItem> ToSelectItems(string value = "")
        {
            throw new System.NotImplementedException();
        }

        public string Add(Button model)
        {
            return Db.SaveAdd(model)?model.ButtonID:null;
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(id);
        }

        public bool Update(Button model, string note = "")
        {
            throw new System.NotImplementedException();
        }

        public Button Find(object id)
        {
            return Db.Buttons.Find(id);
        }

        public System.Collections.Generic.List<Button> All()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<Button> All(System.Func<Button, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public Button Find(object[] id)
        {
            throw new System.NotImplementedException();
        }
    }
}

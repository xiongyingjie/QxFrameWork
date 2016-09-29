using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Contents.Entity;
using Qx.Contents.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Contents.Repository
{


    public class PageControlTypeRepository : BaseRepository, IRepository<PageControlType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.PageControlTypes.Select(a => new SelectListItem() { Text = a.PCT_Name, Value = a.PCT_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(PageControlType model)
        {
            model.PCT_ID = Pk;
            if (Find(model.PCT_ID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
            }
            else
            {
                return "";
            }
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(PageControlType model, string note = "")
        {
            if (Find(model.PCT_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public PageControlType Find(object id)
        {

            return Db.PageControlTypes.NoTrackingFind(a => a.PCT_ID == (string)id);  
        }

        public List<PageControlType> All()
        {

            return Db.PageControlTypes.NoTrackingToList(); 
        }

        public List<PageControlType> All(Func<PageControlType, bool> filter)
        {

            return Db.PageControlTypes.NoTrackingWhere(filter);  
        }
    }
}

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


    public class ContentTableDesignRepository : BaseRepository, IRepository<ContentTableDesign>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ContentTableDesigns.Select(a => new SelectListItem() { Text = a.TableName, Value = a.CTD_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(ContentTableDesign model)
        {
            model.CTD_ID = Pk;
            if (Find(model.CTD_ID) == null)
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

        public bool Update(ContentTableDesign model, string note = "")
        {
            if (Find(model.CTD_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ContentTableDesign Find(object id)
        {

            return Db.ContentTableDesigns.NoTrackingFind(a => a.CTD_ID == (string)id);  
        }

        public List<ContentTableDesign> All()
        {

            return Db.ContentTableDesigns.NoTrackingToList(); 
        }

        public List<ContentTableDesign> All(Func<ContentTableDesign, bool> filter)
        {

            return Db.ContentTableDesigns.NoTrackingWhere(filter);  
        }
    }
}

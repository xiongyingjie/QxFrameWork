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


    public class ContentColumnDesignRepository : BaseRepository, IRepository<ContentColumnDesign>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ContentColumnDesigns.Select(a => new SelectListItem() { Text = a.ColumnName, Value = a.CCD_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(ContentColumnDesign model)
        {
            model.CCD_ID = Pk;
            if (Find(model.CCD_ID) == null)
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

        public bool Update(ContentColumnDesign model, string note = "")
        {
            if (Find(model.CCD_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ContentColumnDesign Find(object id)
        {

            return Db.ContentColumnDesigns.NoTrackingFind(a => a.CCD_ID == (string)id);  
        }

        public List<ContentColumnDesign> All()
        {

            return Db.ContentColumnDesigns.NoTrackingToList(); 
        }

        public List<ContentColumnDesign> All(Func<ContentColumnDesign, bool> filter)
        {

            return Db.ContentColumnDesigns.NoTrackingWhere(filter);  
        }
    }
}

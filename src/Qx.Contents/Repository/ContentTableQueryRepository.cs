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


    public class ContentTableQueryRepository : BaseRepository, IRepository<ContentTableQuery>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ContentTableQueries.Select(a => new SelectListItem() { Text = a.CTQ_ID, Value = a.CTQ_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(ContentTableQuery model)
        {
            model.CTQ_ID = Pk;
            if (Find(model.CTQ_ID) == null)
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

        public bool Update(ContentTableQuery model, string note = "")
        {
            if (Find(model.CTQ_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ContentTableQuery Find(object id)
        {

            return Db.ContentTableQueries.NoTrackingFind(a => a.CTQ_ID == (string)id);  
        }

        public List<ContentTableQuery> All()
        {

            return Db.ContentTableQueries.NoTrackingToList(); 
        }

        public List<ContentTableQuery> All(Func<ContentTableQuery, bool> filter)
        {

            return Db.ContentTableQueries.NoTrackingWhere(filter);  
        }
    }
}

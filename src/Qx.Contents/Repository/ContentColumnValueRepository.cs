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


    public class ContentColumnValueRepository : BaseRepository, IRepository<ContentColumnValue>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ContentColumnValues.Select(a => new SelectListItem() { Text = a.ColumnValue, Value = a.CCV_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(ContentColumnValue model)
        {
            model.CCV_ID = Pk;
            if (Find(model.CCV_ID) == null)
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

        public bool Update(ContentColumnValue model, string note = "")
        {
            if (Find(model.CCV_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ContentColumnValue Find(object id)
        {

            return Db.ContentColumnValues.NoTrackingFind(a => a.CCV_ID == (string)id);  
        }

        public List<ContentColumnValue> All()
        {

            return Db.ContentColumnValues.NoTrackingToList(); 
        }

        public List<ContentColumnValue> All(Func<ContentColumnValue, bool> filter)
        {

            return Db.ContentColumnValues.NoTrackingWhere(filter);  
        }
    }
}

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


    public class ContentTypeRepository : BaseRepository, IRepository<ContentType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ContentTypes.Select(a => new SelectListItem() { Text = a.TypeName, Value = a.CT_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(ContentType model)
        {
            model.CT_ID = Pk;
            if (Find(model.CT_ID) == null)
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

        public bool Update(ContentType model, string note = "")
        {
            if (Find(model.CT_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ContentType Find(object id)
        {

            return Db.ContentTypes.NoTrackingFind(a => a.CT_ID == (string)id);  
        }

        public List<ContentType> All()
        {

            return Db.ContentTypes.NoTrackingToList(); 
        }

        public List<ContentType> All(Func<ContentType, bool> filter)
        {

            return Db.ContentTypes.NoTrackingWhere(filter);  
        }
    }
}

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


    public class DataTypeRepository : BaseRepository, IRepository<DataType>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.DataTypes.Select(a => new SelectListItem() { Text = a.TypeName, Value = a.DT_ID }).ToList();
            return dest.Format(value);
        }

        public string Add(DataType model)
        {
            model.DT_ID = Pk;
            if (Find(model.DT_ID) == null)
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

        public bool Update(DataType model, string note = "")
        {
            if (Find(model.DT_ID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public DataType Find(object id)
        {

            return Db.DataTypes.NoTrackingFind(a => a.DT_ID == (string)id);  
        }

        public List<DataType> All()
        {

            return Db.DataTypes.NoTrackingToList(); 
        }

        public List<DataType> All(Func<DataType, bool> filter)
        {

            return Db.DataTypes.NoTrackingWhere(filter);  
        }
    }
}

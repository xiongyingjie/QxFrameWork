
using Qx.Permission.Entity;

namespace Qx.Permission.Services
{
    public class BaseRepository
    {
        private PermissionContext db;

        protected PermissionContext Db
        {
            get
            {
                if (db == null)
                {
                    db = new PermissionContext();
                }
                return db;
            }
        }
    }
}

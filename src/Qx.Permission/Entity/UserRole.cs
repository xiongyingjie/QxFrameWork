namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        [StringLength(40)]
        public string UserRoleID { get; set; }

        [Required]
        [StringLength(20)]
        public string UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }

        [StringLength(10)]
        public string Note { get; set; }

        public DateTimeOffset? ExpireTime { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}

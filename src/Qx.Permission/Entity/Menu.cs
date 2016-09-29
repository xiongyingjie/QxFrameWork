namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            Buttons = new HashSet<Button>();
            RoleMenus = new HashSet<RoleMenu>();
        }

        [StringLength(100)]
        public string MenuID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string FartherID { get; set; }

        [StringLength(10)]
        public string Note { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Value { get; set; }

        [Required]
        [StringLength(10)]
        public string Level { get; set; }

        public int IsAvailable { get; set; }

        public int? Sequence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Button> Buttons { get; set; }

        public virtual MenuExtension MenuExtension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
    }
}

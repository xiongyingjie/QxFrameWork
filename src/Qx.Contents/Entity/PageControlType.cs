namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageControlType")]
    public partial class PageControlType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PageControlType()
        {
            ContentColumnDesigns = new HashSet<ContentColumnDesign>();
        }

        [Key]
        [StringLength(50)]
        public string PCT_ID { get; set; }

        [StringLength(50)]
        public string PCT_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentColumnDesign> ContentColumnDesigns { get; set; }
    }
}

namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentTableDesign")]
    public partial class ContentTableDesign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContentTableDesign()
        {
            ContentColumnDesigns = new HashSet<ContentColumnDesign>();
            ContentTableQueries = new HashSet<ContentTableQuery>();
        }

        [Key]
        [StringLength(50)]
        public string CTD_ID { get; set; }

        [StringLength(50)]
        public string CT_ID { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentColumnDesign> ContentColumnDesigns { get; set; }

        public virtual ContentType ContentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentTableQuery> ContentTableQueries { get; set; }
    }
}

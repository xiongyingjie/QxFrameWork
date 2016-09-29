namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentColumnDesign")]
    public partial class ContentColumnDesign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContentColumnDesign()
        {
            ContentColumnValues = new HashSet<ContentColumnValue>();
        }

        [Key]
        [StringLength(50)]
        public string CCD_ID { get; set; }

        [StringLength(50)]
        public string CTD_ID { get; set; }

        [StringLength(20)]
        public string DT_ID { get; set; }

        [StringLength(50)]
        public string PCT_ID { get; set; }

        [StringLength(50)]
        public string ColumnName { get; set; }

        [StringLength(50)]
        public string Seq { get; set; }

        [StringLength(50)]
        public string IsPk { get; set; }

        [StringLength(50)]
        public string DefValue { get; set; }

        public virtual ContentTableDesign ContentTableDesign { get; set; }

        public virtual DataType DataType { get; set; }

        public virtual PageControlType PageControlType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentColumnValue> ContentColumnValues { get; set; }
    }
}

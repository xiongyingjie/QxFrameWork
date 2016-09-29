namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentColumnValue")]
    public partial class ContentColumnValue
    {
        [Key]
        [StringLength(50)]
        public string CCV_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CCD_ID { get; set; }

        [StringLength(150)]
        public string ColumnValue { get; set; }

        [StringLength(50)]
        public string RelationKeyValue { get; set; }

        public virtual ContentColumnDesign ContentColumnDesign { get; set; }
    }
}

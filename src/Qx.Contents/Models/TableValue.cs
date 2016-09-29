using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Contents.Models
{
  public  class TableValue
    {
        [Key]
        public string TableID { get; set; }
        public string TypeID { get; set; }
        public string RelationKeyID { get; set; }
        public string TypeName { get; set; }
        public string TableName { get; set; }
        public IEnumerable<TableColumn> Columns { get; set; }
    }
}

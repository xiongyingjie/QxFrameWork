using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qx.Contents.Models
{
  public  class ContentBag
  {
        public string TableId { get; set; }
        public IEnumerable<ContentValue> Values;
  }
}

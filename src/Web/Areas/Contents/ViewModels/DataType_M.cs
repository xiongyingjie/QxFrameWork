using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;

namespace Web.Areas.Contents.ViewModels
{
    public class DataType_M
    {
        public Qx.Contents.Entity.DataType ToModel()
        {
            return new Qx.Contents.Entity.DataType() {DT_ID=DT_ID,TypeName=TypeName };
        }
        public static DataType_M ToViewModel(Qx.Contents.Entity.DataType dataType)
        {
            return new DataType_M() {DT_ID=dataType.DT_ID, TypeName=dataType.TypeName};
        }
        [Display(Name = "数据类型ID")]
        [Key]
        [StringLength(20)]
        public string DT_ID { get; set; }
        [Display(Name = "数据类型名称")]
        [StringLength(50)]
        public string TypeName { get; set; }
    }
}
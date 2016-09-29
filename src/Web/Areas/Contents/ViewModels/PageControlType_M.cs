using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Contents.Entity;

namespace Web.Areas.Contents.ViewModels
{
    public class PageControlType_M
    {
        public PageControlType ToModel()
        {
            return new PageControlType(){PCT_ID = PCT_ID,PCT_Name = PCT_Name};
        }

        public static PageControlType_M ToViewModel(PageControlType model)
        {
            return new PageControlType_M(){PCT_ID = model.PCT_ID,PCT_Name = model.PCT_Name};
        }
        [Display(Name = "控件ID")]
        [Key]
        [StringLength(50)]
        public string PCT_ID { get; set; }

        [StringLength(50)]
        [Display(Name = "控件名称")]
        public string PCT_Name { get; set; }
    }
}
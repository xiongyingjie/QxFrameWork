using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels.Report
{
    public class Add_M
    {
        public Qx.Report.Models.Report ToModel()
        {
            return new Qx.Report.Models.Report() { ReportID= ReportID,ReportName=ReportName, SqlStr=SqlStr, ColunmToShow=ColunmToShow,
             HeadFields=HeadFields, OperateColum=OperateColum, ParaNames=ParaNames, RecordsPerPage=RecordsPerPage};
        }
        [Display(Name = "编号ID")]
        public string ReportID { get; set; }
        [Display(Name = "名称")]
        public string ReportName { get; set; }
        [Display(Name = "Sql脚本")]
        public string SqlStr { get; set; }
        [Display(Name = "标题")]
        public string HeadFields { get; set; }
        [Display(Name = "每页显示条数")]
        public int RecordsPerPage { get; set; }
        [Display(Name = "参数说明")]
        public string ParaNames { get; set; }
        [Display(Name = "要显示的列索引")]
        public string ColunmToShow { get; set; }
        [Display(Name = "操作列")]
        public string OperateColum { get; set; }

    }
}
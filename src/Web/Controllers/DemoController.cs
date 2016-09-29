using System;
using System.Web.Mvc;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Web.Controllers.Base;
using Web.ViewModels.Demo;

namespace Web.Controllers
{
    public class DemoController : BaseAccountController
    {
        //
        // GET: /Demo/

        private IContents _contents;
        public DemoController(IContents contents)
        {
            _contents = contents;
        }

        public ActionResult Index()
        {
            InitForm("表单控件模版");
            return View();
        }
        // /Demo/Form
        public ActionResult Form()
        {
            var temp = _contents.GetTableValue("10001", "我是relationKeyId");
            InitForm("FormDemo");
            return View(Form_M.ToViewModel(1,"我是string",DateTime.Now, 1.23f,2.42343243432434d,'a'));
        }
        [HttpPost]
        [ValidateInput(true)]//当表单中存在富文本输入的时候需要加上这句
        public ActionResult Form(Form_M model)
        {
            
            
            if (ModelState.IsValid)
            {
                Request.UpdateTable("10001", "我是relationKeyId");
                return Alert("提交成功");
            }
            else
            {
                InitForm("FormDemo");
                return View(model);
            }
           
        }
        // /Demo/Report?ReportID=报表Demo&Params=;
        public ActionResult Report(string ReportID , string Params , int pageIndex = 1, int perCount = 10)
        {
            InitReport("ReportDemo(后端分页)", "#", pageIndex, perCount, "", true, "Qx.System");
            return View();
        }
        // /Demo/Report2?ReportID=System&Params=;
        public ActionResult Report2(string ReportID, string Params)
        {
            InitReport("ReportDemo(前端分页)", "#", "",true ,"Qx.System");
            return View();
        }
    }
}

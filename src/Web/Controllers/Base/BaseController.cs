using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Controller;

namespace Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected DataContext DataContext
        {
            get
            {
                var hsaValue = Session["DataContext"] as DataContext;
                if (hsaValue ==null)
                {
                    Session["DataContext"] = new DataContext();
                }
                return Session["DataContext"] as DataContext;
            }
            set
            {
                Session["DataContext"] = value;
            }
        }


        protected string ToPhysicPath(string FilePath)
        {
            return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;//System.Web.HttpContext.Current.Server.MapPath(SavePath) + fileBase.FileName;
        }
        protected string ReadFile(string FilePath)
        {
            var filePath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;
            var temp = new List<char>();
            if (System.IO.File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var br = new BinaryReader(fs, Encoding.UTF8);
                    //判断是否已经读到文件末尾
                    while (br.PeekChar() != -1)//使用while(temp=br.ReadString())!=null 会报异常System.IO.EndOfStreamExceptionl 
                    {
                        temp.Add(br.ReadChar());
                    }
                    br.Close();
                    fs.Close();
                }
            }
            return new string(temp.ToArray());
        }

        protected string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        protected string CurrentUrl()
        {
            return System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        }
        protected string CurrentFullUrl()
        {
            return System.Web.HttpContext.Current.Request.RawUrl;
        }
      
        protected string ReturnUrl
        {
            get
            {
                return Session["ReturnUrl"] != null ? Session["ReturnUrl"].ToString() : "/";
            }
            set
            {
                Session["ReturnUrl"] = value;
            }
        }
        protected void InitLayout(string Title)
        {
            ViewData["UserID"] = DataContext.UserID;
            ViewData["Url"] = CurrentUrl(); ViewData["Title"] = Title;
            // HttpContext.Items.Add("Layout","~/Views/Shared/_PandaLayout.cshtml");ViewData["Layout"] = "~/Views/Shared/_PandaLayout.cshtml";
            HttpContext.Items.Add("Layout", "~/Views/Shared/_SbLayout.cshtml"); ViewData["Layout"] = "~/Views/Shared/_SbLayout.cshtml";
        }
        protected void InitAdminLayout(string Title)
        {
            ViewData["UserID"] = DataContext.UserID;
            ViewData["Url"] = CurrentUrl(); ViewData["Title"] = Title;
           // HttpContext.Items.Add("Layout","~/Views/Shared/_PandaLayout.cshtml");ViewData["Layout"] = "~/Views/Shared/_PandaLayout.cshtml";
            HttpContext.Items.Add("Layout", "~/Views/Shared/_SbAdminLayout.cshtml"); ViewData["Layout"] = "~/Views/Shared/_SbAdminLayout.cshtml";
        }
        protected void InitForm(string Title,bool ShowSaveButton=true)
        {
            ViewData["UserID"] = DataContext.UserID;
            ViewData["Url"] = CurrentUrl(); ViewData["Title"] = Title; ViewData["ShowSaveButton"] = ShowSaveButton;
            HttpContext.Items.Add("Layout", "~/Views/Shared/_PandaFormLayout.cshtml");
            // HttpContext.Items["Layout"] = "~/Views/Shared/_PandaFormLayout.cshtml"; ViewData["Layout"] = "~/Views/Shared/_PandaFormLayout.cshtml";
            HttpContext.Items["Layout"] = "~/Views/Shared/_SbFormLayout.cshtml"; ViewData["Layout"] = "~/Views/Shared/_SbFormLayout.cshtml";
        }
        protected void InitReport(string Title, string AddLink, int pageIndex, int perCount,string ExtraParam="",bool showDeafultButton=true, string dbConnStringKey = null)
        {
            ViewData["UserID"] = DataContext.UserID;
            InitReport(Title, AddLink, ExtraParam, showDeafultButton, dbConnStringKey);
            ViewData["pageIndex"] = Request.QueryString["pageIndex"] ?? "1"; ViewData["perCount"] = Request.QueryString["perCount"] ?? "10";//分页参数
        }
        protected void InitReport(string Title, string AddLink, string ExtraParam = "", bool showDeafultButton = true, string dbConnStringKey = null)
        {

            if (!dbConnStringKey.HasValue())
            {
                throw new Exception("报表数据库配置错误！");
            }
            ViewData["UserID"] = DataContext.UserID;
            ViewData["showDeafultButton"] = showDeafultButton;
            ViewData["dbConnStringKey"] = dbConnStringKey;
            ViewData["ExtraParam"] = ExtraParam;
            ViewData["AddLink"] = AddLink; ViewData["Url"] = CurrentUrl(); ViewData["Title"] = Title;
            ViewData["ReportID"] = Request.QueryString["ReportID"]; ViewData["Params"] = Request.QueryString["Params"];
           // ViewData["Layout"] = "~/Views/Shared/_PandaReportLayout.cshtml"; HttpContext.Items.Add("Layout", "~/Views/Shared/_PandaReportLayout.cshtml");
            ViewData["Layout"] = "~/Views/Shared/_SbReportLayout.cshtml"; HttpContext.Items.Add("Layout", "~/Views/Shared/_SbReportLayout.cshtml");
        }
        protected List<T> InitCutPage<T>(IEnumerable<T> data, int pageIndex, int perCount)
        {
            int maxIndex;
            var model = data.GetPage(pageIndex, perCount, out maxIndex);
            ViewData["currentUrl"] = CurrentUrl();
            ViewData["maxIndex"] = maxIndex; ViewData["pageIndex"] = pageIndex; ViewData["perCount"] = perCount;
            return model.ToList();
        }
       
        protected string Q(string key)
        {
            return Request.QueryString[key];

        }
        protected string F(string key)
        {
            return Request.Form[key];

        }
        protected void AddParam(string Param)
        {
            var Params = Q("Params");
            if (Params.Length > 2 && Param[Param.Length - 1] != ';')
            {
                Params += ';';
            }

            ViewData["Params"] = Params + Param + ";";
        }

        protected void InitMenu(Dictionary<string, string> Menus)
        {
            ViewBag.Menus = Menus; ViewData["Title"] = "菜单列表";
            ViewData["Layout"] = "~/Views/Shared/_SbLayout.cshtml";
        }
        protected string GetProjectDir(string FileName)
        {
            return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName+ FileName;
        }
        protected void WriteFile(string FilePath, string content)
        {
            var filePath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;
            var temp = new List<char>();
            if (System.IO.File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var br = new BinaryWriter(fs, Encoding.UTF8);
                    br.Write(true);
                    br.Flush();
                    br.Close();
                    fs.Close();
                }
            }
        }


        #region 文件上传 public
        static string TempPath = null;
        [HttpPost]
        public JsonResult UploadHandle(string saveDirectory)
        {
            var fileBase = System.Web.HttpContext.Current.Request.Files[0];
            var SavePath = saveDirectory;// "/UserFiles/Test/";
            var TargetPath =   System.Web.HttpContext.Current.Server.MapPath(SavePath) + fileBase.FileName;
            var ContentRange = Request.Headers["Content-Range"];
            TempPath = TargetPath;
            FileUploadUtility.UploadBigFile(fileBase, TargetPath, ContentRange);
            var result = new { name = "提示:上传成功！", filePath = saveDirectory + fileBase.FileName };
            return Json(result);
        }

        public ActionResult RedoHandle()
        {
            //处理Redo按钮的请求
            int command = Convert.ToInt32(Request["DeleteCommand"]);
            if (command == 1 && TempPath != null)
            {
                if (System.IO.File.Exists(TempPath))//判断文件是否存在
                {
                    System.IO.File.Delete(TempPath);//执行IO文件删除,需引入命名空间System.IO;    
                } //删除物理文件
                TempPath = null;
                return Content("删除成功!");
            }
            else
            {
                return Content("删除异常!");
            }
        }

        public ActionResult ContinueHandle()
        {
            //用于处理续传功能
            //var FileByte = System.IO.File.ReadAllBytes(TempPath);
            //var resp = new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new ByteArrayContent(FileByte)
            //};
            //var fileStream = new FileStream(TempPath, FileMode.Open);
            string CurrentFileName = Request["file"];
            FileInfo info = new FileInfo(TempPath);
            long InfoSize = info.Length;
            var result = new { FileSize = InfoSize };
            return Json(result);
        }

        protected ActionResult FreshHandle()
        {
            TempPath = null;
            return View();
        }
        #endregion
        protected ActionResult Alert(string content)
        {
            return Content(PageHelper.Tip(content));
        }
        protected ActionResult Alert(string content, int returnIndex)
        {
            return Content(PageHelper.Tip(content, returnIndex));
        }
        protected ActionResult Alert(string content, string returnUrl)
        {
            return Content(PageHelper.Tip(content, returnUrl));
        }
     
  

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var item in Request.QueryString)
            {
                if (item == null) continue;
                var key = item.ToString() ?? "";
                ViewData[key] = Request.QueryString[key];
            }
            ViewData["CurrentUrl"] = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
            ViewData["CurrentFullUrl"] = filterContext.RequestContext.HttpContext.Request.RawUrl;
            base.OnActionExecuting(filterContext);
        }

    }
}

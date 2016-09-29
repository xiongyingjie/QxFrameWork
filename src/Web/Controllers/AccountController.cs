using System.Web.Mvc;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AccountController : BaseController
    {
        // GET: /Account/Login
        public ActionResult Index(string msg)
        {
            if (!msg.HasValue())
            {
                return RedirectToAction("Login");
            }

            InitAdminLayout("");
            return View();
        }
        #region 登录
        public ActionResult Login()
        {
            InitLayout("");
            if (DataContext.UserID.HasValue())
            {
                return RedirectToAction("Index", new { msg = "用户" + DataContext.UserID + "已登录，切换账号请先 退出登录" });
            }
            else
            {
                return View(new Login_M() { UserId = "panda", UserPsw = "123" });
            }

        }


        [HttpPost]
        public ActionResult Login(Login_M model)
        {
            model.UserId = Request.Form["UserId"];
            model.UserPsw = Request.Form["UserPsw"];
            var accountContext = new AccountContext();
            DataContext.UserID =
                accountContext.UserID = model.UserId;

            Session["AccountContext"] = accountContext;
            if (ReturnUrl.HasValue())
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", new { msg = "用户[" + model.UserId + "]登录成功!" });
            }

        }

        #endregion
        public ActionResult LoginOut()
        {
            //退出登录前准备工作
            Session.Clear();
            if (Session["AccountContext"] != null)
            {
                Session.Remove("AccountContext");
            }
            return RedirectToAction("Index", new { msg = "退出登录成功!" });
        }
        public ActionResult Forget()
        {
            return Alert("请联系管理员重置密码");
        }

        #region 注册
        public ActionResult Regist()
        {
            return Alert("暂未开放注册，请联系管理员商议入驻事宜！");
            // return View();
        }

        #endregion
    }
}
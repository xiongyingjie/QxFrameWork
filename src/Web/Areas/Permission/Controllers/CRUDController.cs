using System.Web.Mvc;
using Qx.Permission.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Areas.Permission.ViewModels.CRUD;

namespace Web.Areas.Permission.Controllers
{
    public class CRUDController : BasePermissionController
    {
        //
        // GET: /Permision2/CRUD/

        private IRepository<Button> _funcObject;
        private IRepository<Menu> _module;
        private IRepository<RoleButtonForbid> _roleFuncObjForbid;
        private IRepository<RoleMenu> _roleModule;
        private IRepository<Role> _role;
        private IRepository<User> _user;
        private IRepository<UserRole> _userRole;

        public CRUDController(IRepository<Button> funcObject, IRepository<Menu> module,
            IRepository<RoleButtonForbid> roleFuncObjForbid, IRepository<RoleMenu> roleModule,
            IRepository<Role> role, IRepository<User> user,
            IRepository<UserRole> userRole)
        {
            _funcObject = funcObject;
            _module = module;
            _roleFuncObjForbid = roleFuncObjForbid;
            _roleModule = roleModule;
            _role = role;
            _user = user;
            _userRole = userRole;
        }

        public ActionResult Index()
        {

            var temp = _user.All();

            return View();
        }
     
        public ActionResult UserAdd()
        {
            InitForm("添加用户");
            return View(new UserAdd_M());
        }
        [HttpPost]
        public ActionResult UserAdd(UserAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_user.Find(model.userid) == null)
                {
                    _user.Add(model.ToModel());
                    return Redirect(BackToReport);
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加用户");
                return View(model);
            }
        }
        public ActionResult RoleMenuAdd(string roleid,string menuid)
        {
            var role = _role.Find(roleid);
            InitForm("分配菜单");
            if (menuid.HasValue())
            {
                var menu = _module.Find(menuid);
                return View(RoleMenuAdd_M.ToViewModel(roleid,role.Name, menuid, menu.Name));
            }
            else
            {
                return View(RoleMenuAdd_M.ToViewModel(roleid,role.Name, menuid));
            }
        }
        [HttpPost]
        public ActionResult RoleMenuAdd(RoleMenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.RoleMenuID = model.RoleID + model.MenuID;
                if (_roleModule.Find(model.RoleMenuID) == null)
                {
                    _roleModule.Add(model.ToModel());
                    return Redirect("/Permision2/Admin/RoleMenuList?ReportID=Permision_分配菜单&Params="+model.RoleID);
                }
                else
                    return Alert("操作失败!");
            }
            else
            {
                InitForm("分配菜单");
                return View(model);
            }
        }
        public ActionResult BanButtonAdd(string roleid,string buttonid)
        {
            var role = _role.Find(roleid);
            if (buttonid.HasValue())
            {
                var button = _funcObject.Find(buttonid);
                InitForm("禁用按钮");
                return View(BanButtonAdd_M.ToViewModel(roleid, role.Name, buttonid, button.Name));
            }
            else
            {
                InitForm("禁用按钮");
                return View(BanButtonAdd_M.ToViewModel(roleid, role.Name));
            }
        }
        [HttpPost]
        public ActionResult BanButtonAdd(BanButtonAdd_M model)
        {
            if(ModelState.IsValid)
            {
            model.roleButtonForbidID = model.roleid + "-" + model.buttonid;
            if (_roleFuncObjForbid.Find(model.roleButtonForbidID) == null)
            {
                _roleFuncObjForbid.Add(model.ToModel());
                return Redirect("/Permision2/Admin/BanButtonList?ReportID=Permision_按钮禁用&Params=" + model.roleid);
            }
            else
                return Alert("操作失败!");
            }
            else
            {
                InitForm("禁用按钮");
                return View(model);
            }
        }
        public ActionResult RoleAdd()
        {
            InitForm("添加角色");
            return View(new RoleAdd_M());
        }
        [HttpPost]
        public ActionResult RoleAdd(RoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_role.Find(model.roleid) == null)
                {
                    _role.Add(model.ToModel());
                    return Redirect(BackToReport);
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加角色");
                return View(model);
            }
        }
        public ActionResult UserRoleAdd(string userid,string roleid)
        {
            if (roleid.HasValue())
            {
                var role = _role.Find(roleid);
                InitForm("分配角色");
                return View(UserRoleAdd_M.ToViewModel(userid, roleid, role.Name));
            }
            else
            {
                InitForm("分配角色");
                return View(UserRoleAdd_M.ToViewModel(userid));
            }
        }
        [HttpPost]
        public ActionResult UserRoleAdd(UserRoleAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.UserRoleID = model.userid + model.roleid;
                if (_userRole.Find(model.UserRoleID) == null)
                {
                    _userRole.Add(model.ToModel());
                    return Redirect("/Permision2/Admin/UserRoleList?ReportID=Permision_分配角色&Params="+model.roleid);
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("分配角色");
                return View(model);
            }
        }
        
        public ActionResult ButtonAdd(string menuid)
        {
            InitForm("添加按钮");
            if (menuid.HasValue())
                return View(ButtonAdd_M.ToViewModel(menuid));
            else
               return View(new ButtonAdd_M());
        }
        [HttpPost]
        public ActionResult ButtonAdd(ButtonAdd_M model)
        {
            if (ModelState.IsValid)
            {
                model.buttonid = model.menuid + "-" + model.name;
                if (_funcObject.Find(model.buttonid) == null)
                {
                    _funcObject.Add(model.ToModel());
                    return Redirect("/Permision2/Admin/ButtonList?ReportID=Permision_按钮列表&Params=;");
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加按钮");
                return View(model);
            }
        }
        public ActionResult MenuAdd(string fartherid)
        {
            if (fartherid==";")
                fartherid = "MRoot";
            InitForm("添加菜单");
            return View(MenuAdd_M.ToViewModel(fartherid));
        }
        [HttpPost]
        public ActionResult MenuAdd(MenuAdd_M model)
        {
            if (ModelState.IsValid)
            {
                if (_module.Find(model.menuid) == null)
                {
                    _module.Add(model.ToModel());
                    return Redirect(BackToReport);
                }
                else
                    return Alert("添加失败，请重新添加");
            }
            else
            {
                InitForm("添加菜单");
                return View(model);
            }
           
        }
        public ActionResult UserDelete(string userid)
        {
            var user=_user.Find(userid);
            if (user != null)
            {
                _user.Delete(user);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult RoleDelete(string roleid)
        {
            var role = _role.Find(roleid);
            if (role != null)
            {
                _role.Delete(role);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败!");
        }
        public ActionResult UserRoleDelete(string userroleid)
        {
            var userrole = _userRole.Find(userroleid);
            if (userrole != null)
            {
                _userRole.Delete(userrole);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult RoleMenuDelete(string rolemenuid)
        {
            var rolemenu = _roleModule.Find(rolemenuid);
            if (rolemenu != null)
            {
                _roleModule.Delete(rolemenu);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult BanButtonDelete(string banbuttonid)
        {
            var banbutton = _roleFuncObjForbid.Find(banbuttonid);
            if (banbutton != null)
            {
                _roleFuncObjForbid.Delete(banbutton);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult ButtonDelete(string buttonid)
        {
            var button = _funcObject.Find(buttonid);
            if (button != null)
            {
                _funcObject.Delete(button);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult MenuDelete(string menuid)
        {
            var menu =_module.Find(menuid);
            if (menu != null)
            {
                _module.Delete(menu);
                return Alert("删除成功");
            }
            else
                return Alert("操作失败！");
        }
        public ActionResult MenuEdit(string menuid)
        {
            InitForm("菜单编辑");
            var menu = _module.Find(menuid);
            if (menu == null)
                return Alert("操作失败");
            else
                return View(MenuEdit_M.ToViewModel(menu));
        }
        [HttpPost]
        public ActionResult MenuEdit(MenuEdit_M model)
        {
            if (ModelState.IsValid)
            {
                var old = _module.Find(model.menuid);
                old.IsAvailable = model.isavailable;
                old.Level = model.level;
                old.Name = model.name;
                old.Sequence = model.Sequence;
                old.Value = model.value;
                old.FartherID = model._fartherid;
                _module.Update(old);
                return Redirect(BackToReport);
            }
            else
            {
                InitForm("菜单编辑");
                return View(model);
            }
        }
        public ActionResult ChooseBanButton(string roleid, string buttonid)
        {
            return Redirect("/Permision2/CRUD/BanButtonAdd?roleid=" + roleid + "&buttonid=" + buttonid);
        }
        public ActionResult ChooseRole(string userid,string roleid)
        {
            return Redirect("/Permision2/CRUD/UserRoleAdd?userid="+userid+"&roleid="+roleid);
        }
        public ActionResult ChooseMenu(string menuid,string roleid,string buttonid)
        {
            if(!roleid.HasValue())
                return Redirect("/Permision2/CRUD/ButtonAdd?buttonid="+buttonid+"&menuid="+menuid);
            else
                return Redirect("/Permision2/CRUD/RoleMenuAdd?roleid=" + roleid + "&menuid=" + menuid);
        }
    }
}

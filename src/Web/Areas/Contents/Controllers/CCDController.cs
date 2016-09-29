using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Contents.Entity;
using Qx.Tools.Interfaces;
using Web.Areas.Contents.ViewModels;
using Web.Controllers.Base;

namespace Web.Areas.Contents.Controllers
{
    public class CCDController : BaseContentsController,ICrud<CCD_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<ContentColumnDesign> _repository;
        private IRepository<ContentTableDesign> _ctdrepository;
        private IRepository<PageControlType> _pctrepository;
        private IRepository<DataType> _dtrepository;

        public CCDController(IRepository<ContentColumnDesign> repository, IRepository<ContentTableDesign> ctdrepository,
            IRepository<PageControlType> pctrepository, IRepository<DataType> dtrepository)
        {
            _repository = repository;
            _ctdrepository = ctdrepository;
            _pctrepository = pctrepository;
            _dtrepository = dtrepository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "Qx.Contents.内容列", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("内容列", "/Contents/CCD/Create", pageIndex, perCount);
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加内容列");
            return View(CCD_M.ToViewModel(_ctdrepository.ToSelectItems(), _dtrepository.ToSelectItems(), _pctrepository.ToSelectItems()));
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(CCD_M viewModel)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    _repository.Add(viewModel.ToModel());
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("添加内容列");
                    return View(viewModel);
                }
                
            }
            catch(Exception ex)
            {
                return Alert("请联系开发人员\n"+ex.Message);
            }
        }

        // GET: Area/Controller/Edit/5
        public ActionResult Edit(string id)
        {
            InitForm("编辑内容列");
            return View(CCD_M.ToViewModel(_repository.Find(id),_ctdrepository.ToSelectItems(),_dtrepository.ToSelectItems(),_pctrepository.ToSelectItems()));
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(CCD_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("编辑内容列");
                    return View(viewModel);
                }
             
            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

        // GET: Area/Controller/Delete/5
        public ActionResult Delete(string id)
        {
            if (id.HasValue())
            {
                _repository.Delete(id);
                return Alert("删除成功!");
            }
            else
                return Alert("操作失败!");
        }


        // GET: Area/Controller/Details/5
        public ActionResult Details(string id)
        {
            InitForm("这里填写标题");
            // TODO: 这里编写详情逻辑
            return View();
        }

    }
}
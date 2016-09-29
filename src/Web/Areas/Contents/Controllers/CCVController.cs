﻿using Qx.Contents.Entity;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Contents.ViewModels;
using Web.Controllers.Base;
using Qx.Tools.CommonExtendMethods;

namespace Web.Areas.Contents.Controllers
{
    public class CCVController :BaseContentsController,ICrud<CCV_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<ContentColumnValue> _repository;
        private IRepository<ContentColumnDesign> _designrepository;

        public CCVController(IRepository<ContentColumnValue> repository, IRepository<ContentColumnDesign> designrepository)
        {
            _repository = repository;
            _designrepository = designrepository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "Qx.Contents.内容列值", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("内容列值", "/Contents/CCV/Create", pageIndex, perCount);
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加内容列值");
            return View(CCV_M.ToViewModel(_designrepository.ToSelectItems()));
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(CCV_M viewModel)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    viewModel.CCV_ID = DateTime.Now.Random().ToString();
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("添加内容列值");
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
            InitForm("编辑内容列值");
            var ccv = _repository.Find(id);
            if (ccv != null)
            {
                return View(CCV_M.ToViewModel(ccv,_designrepository.ToSelectItems()));
            }
            else
            {
                return Alert("操作失败！");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(CCV_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: 这里编写更新逻辑

                    _repository.Update(viewModel.ToModel());
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("编辑内容列值");
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
                return Alert("删除成功！");
            }
            else
            {
                return Alert("操作失败！");
            }
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
﻿using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class JobPositionController : Controller
    {
        // GET: JobPosition
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View("_List", JobPositionRepo.Get());
        }
        public ActionResult Create()
        {
            return View("_Create");
        }
        [HttpPost]
        public ActionResult Create(JobPositionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = JobPositionRepo.Update(model);
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }
        //GET EDIT
        public ActionResult Edit(int id)
        {
            return View("_Edit", JobPositionRepo.GetById(id));
        }
        //POST EDIT
        [HttpPost]
        public ActionResult Edit(JobPositionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = JobPositionRepo.Update(model);
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Invalid" }, JsonRequestBehavior.AllowGet);
        }
        //GET DELETE
        public ActionResult Delete(int id)
        {
            return View("_Delete", JobPositionRepo.GetById(id));
        }
        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = JobPositionRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);

        }
    }
}
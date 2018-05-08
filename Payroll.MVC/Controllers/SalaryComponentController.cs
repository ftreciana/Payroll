﻿using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class SalaryComponentController : Controller
    {
        // GET: SalaryComponent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View("_List", SalaryComponentRepo.Get());
        }
        //CREATE GET
        public ActionResult Create()
        {
            return View("_Create", new SalaryComponentViewModel());
        }
        //POST
        [HttpPost]
        public ActionResult Create(SalaryComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = SalaryComponentRepo.Update(model);
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

        //EDIT GET
        public ActionResult Edit(int id)
        {
            return View("_Edit", SalaryComponentRepo.GetById(id));
        }

        //POST
        [HttpPost]
        public ActionResult Edit(SalaryComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = SalaryComponentRepo.Update(model);
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

        //DELETE GET
        public ActionResult Delete(int id)
        {
            return View("_Delete", SalaryComponentRepo.GetById(id));
        }
        //POST
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = SalaryComponentRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        }

        //GET DETAILS
        public ActionResult Details(int id)
        {
            return View(SalaryComponentRepo.GetById(id));
        }
    }
}
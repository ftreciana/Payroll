﻿using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class SellingDetailController : Controller
    {
        // GET: SellingDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View("_List", SellingDetailRepo.Get());
        }

        //CREATE GET
        public ActionResult Create()
        {
            return View("_Create");
        }
        //POST
        [HttpPost]
        public ActionResult Create(SellingDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = SellingDetailRepo.Update(model);
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
            return View("_Edit", SellingDetailRepo.GetById(id));
        }

        //POST
        [HttpPost]
        public ActionResult Edit(SellingDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = SellingDetailRepo.Update(model);
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
            return View("_Delete", SellingDetailRepo.GetById(id));
        }
        //POST
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = SellingDetailRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        }
    }
}
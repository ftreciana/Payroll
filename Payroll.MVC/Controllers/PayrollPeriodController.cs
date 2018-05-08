using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class PayrollPeriodController : Controller
    {
        // GET: PayrollPeriod
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectPeriod()
        {
            return PartialView("_SelectPeriod", PayrollPeriodRepo.Get());
        }
        [HttpPost]
        public ActionResult SelectedPeriod(int id)
        {
            if (PayrollPeriodRepo.SelectPeriod(id))
            {
                return Json(new { Success = true, description = PayrollPeriodRepo.SelectedPeriod.Description }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false, description = PayrollPeriodRepo.SelectedPeriod.Description }, JsonRequestBehavior.AllowGet);
            }         
        }

        public ActionResult List()
        {
            return View("_List", PayrollPeriodRepo.Get());
        }
        //CREATE GET
        public ActionResult Create()
        {
            return View("_Create");
        }
        //POST
        [HttpPost]
        public ActionResult Create(PayrollPeriodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = PayrollPeriodRepo.Update(model);
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
            return View("_Edit",PayrollPeriodRepo.GetById(id));
        }

        //POST
        [HttpPost]
        public ActionResult Edit(PayrollPeriodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = PayrollPeriodRepo.Update(model);
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
            return View("_Delete", PayrollPeriodRepo.GetById(id));
        }
        //POST
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = PayrollPeriodRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        }

        //GET DETAILS
        public ActionResult Details(int id)
        {
            return View(PayrollPeriodRepo.GetById(id));
        }
    }
}
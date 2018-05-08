using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View("_List", AttendanceRepo.Get());
        }

        //CREATE
        public ActionResult Create()
        {
            return View("_Create");
        }

        [HttpPost]
        public ActionResult Create(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = AttendanceRepo.Update(model);
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

        //EDIT
        public ActionResult Edit(int id)
        {
            return View("_Edit", AttendanceRepo.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = AttendanceRepo.Update(model);
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

        //DELETE
        public ActionResult Delete(int id)
        {
            return View("_Delete", AttendanceRepo.GetById(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = AttendanceRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);
        }

        //DETAILS
        public ActionResult Details(int id)
        {
            return View(AttendanceRepo.GetById(id));
        }
    }
}
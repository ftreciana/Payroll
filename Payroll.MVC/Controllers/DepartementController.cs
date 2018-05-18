using Payroll.MVC.Security;
using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    [CustomAuthorize(Roles ="Departement")]
    public class DepartementController : Controller
    {
        // GET: Departement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View("_List", DepartementRepo.Get());
        }

        [CustomAuthorize(Roles = "Departement", AccessLevel ="W")]
        public ActionResult Create()
        {
            ViewBag.DivisionList = new SelectList(DivisionRepo.Get(), "Id", "Description");
            return View("_Create");
        }
        //POST CREATE
        [HttpPost]
        public ActionResult Create(DepartementViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = DepartementRepo.Update(model);
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
        [CustomAuthorize(Roles = "Departement", AccessLevel = "W")]
        //GET EDIT
        public ActionResult Edit(int id)
        {
            ViewBag.DivisionList = new SelectList(DivisionRepo.Get(), "Id", "Description");
            return View("_Edit", DepartementRepo.GetById(id));
        }
        //POST EDIT
        [HttpPost]
        public ActionResult Edit(DepartementViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = DepartementRepo.Update(model);
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
            return View("_Delete", DepartementRepo.GetById(id));
        }
        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = DepartementRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error msg" }, JsonRequestBehavior.AllowGet);

        }
    }
}
using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class DepartementRepo
    {
        public static List<DepartementViewModel> Get()
        {
            List<DepartementViewModel> result = new List<DepartementViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Departement
                          join div in db.Division on
                          d.DivisionId equals div.Id
                          select new DepartementViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DivisionId = d.DivisionId,
                              DivisionCode = div.Code,
                              DivisionName = div.Description,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static DepartementViewModel GetById(int id)
        {
            DepartementViewModel result = new DepartementViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.Departement
                          where d.Id == id
                          select new DepartementViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DivisionId = d.DivisionId,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();
            }
            return result;
        }
        public static Responses Update(DepartementViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        Departement departement = db.Departement.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (departement != null)
                        {
                            departement.Code = entity.Code;
                            departement.DivisionId = entity.DivisionId;
                            departement.Description = entity.Description;
                            departement.IsActivated = entity.IsActivated;
                            departement.ModifyBy = "Freeska";
                            departement.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Departement departement = new Departement();
                        departement.Code = entity.Code;
                        departement.DivisionId = entity.DivisionId;
                        departement.Description = entity.Description;
                        departement.IsActivated = entity.IsActivated;
                        departement.CreateBy = "Freeska";
                        departement.CreateDate = DateTime.Now;
                        db.Departement.Add(departement);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
        public static Responses Delete(int id)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    Departement departement = db.Departement.Where(o => o.Id == id).FirstOrDefault();
                    if (departement != null)
                    {
                        db.Departement.Remove(departement);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }
    }
}

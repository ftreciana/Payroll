using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SalaryComponentRepo
    {
        public static List<SalaryComponentViewModel> Get()
        {
            List<SalaryComponentViewModel> result = new List<SalaryComponentViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryComponent
                          select new SalaryComponentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Period = d.Period,
                              Type = d.Type,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static SalaryComponentViewModel GetById(int id)
        {
            SalaryComponentViewModel result = new SalaryComponentViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryComponent
                          where d.Id == id
                          select new SalaryComponentViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              Description = d.Description,
                              Period = d.Period,
                              Type = d.Type,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(SalaryComponentViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SalaryComponent salaryComponent = db.SalaryComponent.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (salaryComponent != null)
                        {
                            salaryComponent.Code = entity.Code;
                            salaryComponent.Description = entity.Description;
                            salaryComponent.Period = entity.Period;
                            salaryComponent.Type = entity.Type;
                            salaryComponent.IsActivated = entity.IsActivated;
                            salaryComponent.ModifyBy = "Freeska";
                            salaryComponent.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SalaryComponent salaryComponent = new SalaryComponent();
                        salaryComponent.Code = entity.Code;
                        salaryComponent.Description = entity.Description;
                        salaryComponent.Period = entity.Period;
                        salaryComponent.Type = entity.Type;
                        salaryComponent.IsActivated = entity.IsActivated;
                        salaryComponent.CreateBy = "Freeska";
                        salaryComponent.CreateDate = DateTime.Now;
                        db.SalaryComponent.Add(salaryComponent);
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
                    SalaryComponent salaryComponent = db.SalaryComponent.Where(o => o.Id == id).FirstOrDefault();
                    if (salaryComponent != null)
                    {
                        db.SalaryComponent.Remove(salaryComponent);
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

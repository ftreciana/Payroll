using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SalaryDefaultValueRepo
    {
        public static List<SalaryDefaultValueViewModel> Get()
        {
            List<SalaryDefaultValueViewModel> result = new List<SalaryDefaultValueViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryDefaultValue
                          select new SalaryDefaultValueViewModel
                          {
                              Id = d.Id,
                              JobPositionId = d.JobPositionId,
                              SalaryComponentId = d.SalaryComponentId,
                              Value = d.Value,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }

        public static SalaryDefaultValueViewModel GetById(int id)
        {
            SalaryDefaultValueViewModel result = new SalaryDefaultValueViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SalaryDefaultValue
                          where d.Id == id
                          select new SalaryDefaultValueViewModel
                          {
                              Id = d.Id,
                              JobPositionId = d.JobPositionId,
                              SalaryComponentId = d.SalaryComponentId,
                              Value = d.Value,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(SalaryDefaultValueViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SalaryDefaultValue salaryDefaultValue = db.SalaryDefaultValue.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (salaryDefaultValue != null)
                        {
                            salaryDefaultValue.JobPositionId = entity.JobPositionId;
                            salaryDefaultValue.SalaryComponentId = entity.SalaryComponentId;
                            salaryDefaultValue.Value = entity.Value;
                            salaryDefaultValue.IsActivated = entity.IsActivated;
                            salaryDefaultValue.ModifyBy = "Freeska";
                            salaryDefaultValue.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SalaryDefaultValue salaryDefaultValue = new SalaryDefaultValue();
                        salaryDefaultValue.JobPositionId = entity.JobPositionId;
                        salaryDefaultValue.SalaryComponentId = entity.SalaryComponentId;
                        salaryDefaultValue.Value = entity.Value;
                        salaryDefaultValue.IsActivated = entity.IsActivated;
                        salaryDefaultValue.CreateBy = "Freeska";
                        salaryDefaultValue.CreateDate = DateTime.Now;
                        db.SalaryDefaultValue.Add(salaryDefaultValue);
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
                    SalaryDefaultValue salaryDefaultValue = db.SalaryDefaultValue.Where(o => o.Id == id).FirstOrDefault();
                    if (salaryDefaultValue != null)
                    {
                        db.SalaryDefaultValue.Remove(salaryDefaultValue);
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

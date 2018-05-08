using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class JobPositionRepo
    {
        public static List<JobPositionViewModel> Get()
        {
            List<JobPositionViewModel> result = new List<JobPositionViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.JobPosition
                          join dep in db.Departement on 
                          d.DepartementId equals dep.Id
                          select new JobPositionViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DepartementId = d.DepartementId,
                              DepartementName = dep.Description,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static JobPositionViewModel GetById(int id)
        {
            JobPositionViewModel result = new JobPositionViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.JobPosition
                          join dep in db.Departement on
                          d.DepartementId equals dep.Id
                          where d.Id == id
                          select new JobPositionViewModel
                          {
                              Id = d.Id,
                              Code = d.Code,
                              DepartementId = d.DepartementId,
                              DepartementName = dep.Description,
                              Description = d.Description,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(JobPositionViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        JobPosition jobPosition = db.JobPosition.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (jobPosition != null)
                        {
                            jobPosition.Code = entity.Code;
                            jobPosition.DepartementId = entity.DepartementId;
                            jobPosition.Description = entity.Description;
                            jobPosition.IsActivated = entity.IsActivated;
                            jobPosition.ModifyBy = "Freeska";
                            jobPosition.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        JobPosition jobPosition = new JobPosition();
                        jobPosition.Code = entity.Code;
                        jobPosition.DepartementId = entity.DepartementId;
                        jobPosition.Description = entity.Description;
                        jobPosition.IsActivated = entity.IsActivated;
                        jobPosition.CreateBy = "Freeska";
                        jobPosition.CreateDate = DateTime.Now;
                        db.JobPosition.Add(jobPosition);
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
                    JobPosition jobPosition = db.JobPosition.Where(o => o.Id == id).FirstOrDefault();
                    if (jobPosition != null)
                    {
                        db.JobPosition.Remove(jobPosition);
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

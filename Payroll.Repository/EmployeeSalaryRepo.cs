﻿using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class EmployeeSalaryRepo
    {
        public static List<EmployeeSalaryViewModel> Get()
        {
            List<EmployeeSalaryViewModel> result = new List<EmployeeSalaryViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.EmployeeSalary
                          join sc in db.SalaryComponent
                          on d.SalaryComponentId equals sc.Id
                          select new EmployeeSalaryViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              PayrollPeriodId = d.PayrollPeriodId,
                              SalaryComponentId = d.SalaryComponentId,
                              SalaryComponentCode = sc.Code,
                              SalaryComponentName = sc.Description,
                              BasicValue = d.BasicValue,
                              FinalValue = d.FinalValue,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static EmployeeSalaryViewModel GetById(int id)
        {
            EmployeeSalaryViewModel result = new EmployeeSalaryViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.EmployeeSalary
                          join sc in db.SalaryComponent
                          on d.SalaryComponentId equals sc.Id
                          where d.Id == id
                          select new EmployeeSalaryViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              PayrollPeriodId = d.PayrollPeriodId,
                              SalaryComponentId = d.SalaryComponentId,
                              SalaryComponentCode = sc.Code,
                              SalaryComponentName = sc.Description,
                              BasicValue = d.BasicValue,
                              FinalValue = d.FinalValue,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();

            }
            return result;
        }

        public static EmployeeSalaryViewModel GetByComponentId(int id)
        {
            EmployeeSalaryViewModel result = new EmployeeSalaryViewModel();
            using (var db = new PayrollContext())
            {
                result = (from sc in db.SalaryComponent                          
                          where sc.Id == id
                          select new EmployeeSalaryViewModel
                          {
                              Id = sc.Id,
                              SalaryComponentId = sc.Id,
                              SalaryComponentCode = sc.Code,
                              SalaryComponentName = sc.Description
                          }).FirstOrDefault();

            }
            return result;
        }
        public static List<EmployeeSalaryViewModel> GetByBadgeId(string badgeId)
        {
            List<EmployeeSalaryViewModel> result = new List<EmployeeSalaryViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.EmployeeSalary
                          join e in db.Employee on d.BadgeId equals e.BadgeId
                          join p in db.PayrollPeriod on d.PayrollPeriodId equals p.Id
                          join sc in db.SalaryComponent on d.SalaryComponentId equals sc.Id
                          where d.BadgeId == badgeId && p.Id == PayrollPeriodRepo.SelectedPeriod.Id
                          select new EmployeeSalaryViewModel
                          {
                              Id = d.Id,
                              BadgeId = d.BadgeId,
                              PayrollPeriodId = d.PayrollPeriodId,
                              SalaryComponentId = d.SalaryComponentId,
                              SalaryComponentCode = sc.Code,
                              SalaryComponentName = sc.Description,
                              BasicValue = d.BasicValue,
                              FinalValue = d.FinalValue,
                              IsActivated = d.IsActivated
                          }).ToList();

            }
            return result;
        }
        public static Responses SaveSalary(List<EmployeeSalaryViewModel> entities)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    foreach(var item in entities)
                    {
                        EmployeeSalary es = db.EmployeeSalary
                            .Where(o => o.PayrollPeriodId == item.PayrollPeriodId
                            && o.BadgeId == item.BadgeId
                            && o.SalaryComponentId == item.SalaryComponentId)
                            .FirstOrDefault();

                        if (es == null)
                        {
                            EmployeeSalary newEs = new EmployeeSalary();
                            newEs.PayrollPeriodId = item.PayrollPeriodId;
                            newEs.SalaryComponentId = item.SalaryComponentId;
                            newEs.BadgeId = item.BadgeId;
                            newEs.BasicValue = item.BasicValue;

                            newEs.CreateBy = "Freeska";
                            newEs.CreateDate = DateTime.Now;

                            db.EmployeeSalary.Add(newEs);
                            db.SaveChanges();
                        }
                        else
                        {
                            es.BasicValue = item.BasicValue;
                            es.ModifyBy = "Freeska";
                            es.ModifyDate = DateTime.Now;

                            db.SaveChanges();
                        }
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
        public static Responses Update(EmployeeSalaryViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        EmployeeSalary employeesalary = db.EmployeeSalary.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (employeesalary != null)
                        {
                            employeesalary.BadgeId = entity.BadgeId;
                            employeesalary.PayrollPeriodId = entity.PayrollPeriodId;
                            employeesalary.SalaryComponentId = entity.SalaryComponentId;
                            employeesalary.BasicValue = entity.BasicValue;
                            employeesalary.FinalValue = entity.FinalValue;
                            employeesalary.IsActivated = entity.IsActivated;
                            employeesalary.ModifyBy = "Freeska";
                            employeesalary.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        EmployeeSalary employeesalary = new EmployeeSalary();
                        employeesalary.BadgeId = entity.BadgeId;
                        employeesalary.PayrollPeriodId = entity.PayrollPeriodId;
                        employeesalary.SalaryComponentId = entity.SalaryComponentId;
                        employeesalary.BasicValue = entity.BasicValue;
                        employeesalary.FinalValue = entity.FinalValue;
                        employeesalary.IsActivated = entity.IsActivated;
                        employeesalary.CreateBy = "Freeska";
                        employeesalary.CreateDate = DateTime.Now;
                        db.EmployeeSalary.Add(employeesalary);
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
                    EmployeeSalary employeesalary = db.EmployeeSalary.Where(o => o.Id == id).FirstOrDefault();
                    if (employeesalary != null)
                    {
                        db.EmployeeSalary.Remove(employeesalary);
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

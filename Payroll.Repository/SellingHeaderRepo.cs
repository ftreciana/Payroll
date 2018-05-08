using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SellingHeaderRepo
    {
        public static List<SellingHeaderViewModel> Get()
        {
            List<SellingHeaderViewModel> result = new List<SellingHeaderViewModel>();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingHeader
                          select new SellingHeaderViewModel
                          {
                              Id = d.Id,
                              Reference = d.Reference,
                              DateOfSelling = d.DateOfSelling,
                              SellingTotal = d.SellingTotal,
                              Payment = d.Payment,
                              IsActivated = d.IsActivated
                          }).ToList();
            }
            return result;
        }
        public static SellingHeaderViewModel GetById(int id)
        {
            SellingHeaderViewModel result = new SellingHeaderViewModel();
            using (var db = new PayrollContext())
            {
                result = (from d in db.SellingHeader
                          where d.Id == id
                          select new SellingHeaderViewModel
                          {
                              Id = d.Id,
                              Reference = d.Reference,
                              DateOfSelling = d.DateOfSelling,
                              SellingTotal = d.SellingTotal,
                              Payment = d.Payment,
                              IsActivated = d.IsActivated
                          }).FirstOrDefault();

            }
            return result;
        }

        public static Responses Update(SellingHeaderViewModel entity)
        {
            Responses result = new Responses();
            try
            {
                using (var db = new PayrollContext())
                {
                    if (entity.Id != 0)
                    {
                        SellingHeader sellingHeader = db.SellingHeader.Where(o => o.Id == entity.Id).FirstOrDefault();
                        if (sellingHeader != null)
                        {
                            sellingHeader.Reference = entity.Reference;
                            sellingHeader.DateOfSelling = entity.DateOfSelling;
                            sellingHeader.SellingTotal = entity.SellingTotal;
                            sellingHeader.Payment = entity.Payment;
                            sellingHeader.IsActivated = entity.IsActivated;
                            sellingHeader.ModifyBy = "Freeska";
                            sellingHeader.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        SellingHeader sellingHeader = new SellingHeader();
                        sellingHeader.Reference = entity.Reference;
                        sellingHeader.DateOfSelling = entity.DateOfSelling;
                        sellingHeader.SellingTotal = entity.SellingTotal;
                        sellingHeader.Payment = entity.Payment;
                        sellingHeader.IsActivated = entity.IsActivated;
                        sellingHeader.CreateBy = "Freeska";
                        sellingHeader.CreateDate = DateTime.Now;
                        db.SellingHeader.Add(sellingHeader);
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
                    SellingHeader sellingHeader = db.SellingHeader.Where(o => o.Id == id).FirstOrDefault();
                    if (sellingHeader != null)
                    {
                        db.SellingHeader.Remove(sellingHeader);
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

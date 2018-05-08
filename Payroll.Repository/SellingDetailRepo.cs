using Payroll.DataModel;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class SellingDetailRepo
    {
            public static List<SellingDetailViewModel> Get()
            {
                List<SellingDetailViewModel> result = new List<SellingDetailViewModel>();
                using (var db = new PayrollContext())
                {
                    result = (from d in db.SellingDetail
                              select new SellingDetailViewModel
                              {
                                  Id = d.Id,
                                  SellingHeaderId = d.SellingHeaderId,
                                  ItemId = d.ItemId,
                                  Quantity = d.Quantity,
                                  Price = d.Price,
                                  Amount = d.Amount,
                                  IsActivated = d.IsActivated
                              }).ToList();
                }
                return result;
            }
            public static SellingDetailViewModel GetById(int id)
            {
            SellingDetailViewModel result = new SellingDetailViewModel();
                using (var db = new PayrollContext())
                {
                    result = (from d in db.SellingDetail
                              where d.Id == id
                              select new SellingDetailViewModel
                              {
                                  Id = d.Id,
                                  SellingHeaderId = d.SellingHeaderId,
                                  ItemId = d.ItemId,
                                  Quantity = d.Quantity,
                                  Price = d.Price,
                                  Amount = d.Amount,
                                  IsActivated = d.IsActivated
                              }).FirstOrDefault();

                }
                return result;
            }

            public static Responses Update(SellingDetailViewModel entity)
            {
                Responses result = new Responses();
                try
                {
                    using (var db = new PayrollContext())
                    {
                        if (entity.Id != 0)
                        {
                        SellingDetail sellingDetail = db.SellingDetail.Where(o => o.Id == entity.Id).FirstOrDefault();
                            if (sellingDetail != null)
                            {
                            sellingDetail.SellingHeaderId = entity.SellingHeaderId;
                            sellingDetail.ItemId = entity.ItemId;
                            sellingDetail.Quantity = entity.Quantity;
                            sellingDetail.Price = entity.Price;
                            sellingDetail.Amount = entity.Amount;
                            sellingDetail.IsActivated = entity.IsActivated;
                            sellingDetail.ModifyBy = "Freeska";
                            sellingDetail.ModifyDate = DateTime.Now;
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                        SellingDetail sellingDetail = new SellingDetail();
                        sellingDetail.SellingHeaderId = entity.SellingHeaderId;
                        sellingDetail.ItemId = entity.ItemId;
                        sellingDetail.Quantity = entity.Quantity;
                        sellingDetail.Price = entity.Price;
                        sellingDetail.Amount = entity.Amount;
                        sellingDetail.IsActivated = entity.IsActivated;
                        sellingDetail.CreateBy = "Freeska";
                        sellingDetail.CreateDate = DateTime.Now;
                            db.SellingDetail.Add(sellingDetail);
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
                    SellingDetail sellingDetail = db.SellingDetail.Where(o => o.Id == id).FirstOrDefault();
                        if (sellingDetail != null)
                        {
                            db.SellingDetail.Remove(sellingDetail);
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

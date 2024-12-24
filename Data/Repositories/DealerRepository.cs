using Data.Context;
using Domain.Entities.Portal.Models;
using Domain.Interfaces;
using Domain.ViewModels.Dealer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DealerRepository:IDealerRepository
    {
        #region DB
        private readonly PouyaContext _context;
        public DealerRepository(PouyaContext context)
        {
            _context = context;
        }
        #endregion
        public List<DisplayDealerVM> GetAll()
        {
            return _context.Dealers.Select(d => new DisplayDealerVM
            {
                Code = d.Code.ToString(),
                Name = d.Name,
                Id = d.Id,
                CityName = d.City.Name,
                DealorNo=d.DealerNo.ToString(),
                Status = (d.Status == 0 ? "فعال" : (d.Status == 1 ? "غیر فعال" : "تعلیق"))
            }).ToList();
        }

        public DisplayDealerByIdVM GetById(Guid id)
        {
            var data = (from dealer in _context.Dealers
                        where (dealer.Id == id)
                        join city in _context.Cities
                          on dealer.CityId equals city.Id
                          select new DisplayDealerByIdVM
                          {
                              Id = dealer.Id,
                              Name = dealer.Name,
                              Status = dealer.Status
                          }).FirstOrDefault();
            return data;
        }

        public bool Insert(Dealer dealer, out string message)
        {
            bool result = false;
            string checkMessage = "";

            try
            {
                if (Similarity(dealer, out checkMessage, "0"))
                {
                    message = checkMessage;
                    return false;
                }

                _context.Dealers.Add(dealer);
                message = "";
                result = true;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                message = $"خطای شکست عملیات  : {ex.Message}";
            }

            return result;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Similarity(Dealer dealer, out string message, string type)
        {
            if(dealer == null)
            {
                message = "اطلاعات ناقص ارسال شده است.";
                return true;
            }

            bool result = false;
            string checkMessage = "";

            if (type == "0")
            {
                result = _context.Dealers.Where(d => d.DealerNo == dealer.DealerNo)
                                         .Any();
            }
            else if (type == "1")
            {
                result = _context.Dealers.Where(d => d.Id != dealer.Id &&
                                                     d.DealerNo == dealer.DealerNo)
                                         .Any();

            }

            if (result)
            {
                checkMessage = "این شمارنده فروشنده قبلا ثبت شده است.";
                result = true;
            }

            message = checkMessage;
            return result;

        }

        public bool Update(Dealer dealer, out string message)
        {
            bool result = false;
            string checkMessage = "عملیات ویرایش موفقیت آمیز نبود.";

            try
            {
                if (Similarity(dealer, out checkMessage, "1"))
                {
                    message = checkMessage;
                    return false;
                }

                var initial = _context.Dealers.Where(d => d.Id == dealer.Id)
                                              .FirstOrDefault();

                if (initial != null)
                {
                    initial.Name = dealer.Name;
                    initial.Status = dealer.Status;

                    _context.Dealers.AddOrUpdate(initial);

                    checkMessage = "";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                checkMessage = $"خطای شکست عملیات  : {ex.Message}";
            }

            message = checkMessage;

            return result;
        }

        public bool Delete(Guid id, out string message)
        {
            bool result = false;

            try
            {
                var dealer = _context.Dealers.Find(id);
                _context.Dealers.Remove(dealer);
                message = "";
                result = true;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                message = $"خطای شکست عملیات  : {ex.Message}";
            }

            return result;
        }
    }
}

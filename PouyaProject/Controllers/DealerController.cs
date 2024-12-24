using Data.Context;
using Data.Repositories;
using Domain.Entities.Portal.Models;
using Domain.Interfaces;
using Domain.ViewModels.City;
using Domain.ViewModels.Dealer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PouyaProject.Controllers
{
    public class DealerController : Controller
    {
        #region Constructor
        private readonly IDealerRepository _dealerRepository;
        private readonly ICityRepository _cityRepository;

        PouyaContext _context = new PouyaContext();
        public DealerController()
        {
            _dealerRepository = new DealerRepository(_context);
            _cityRepository = new CityRepository(_context);
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Get
        public ActionResult GetDealers()
        {
            var dealers = _dealerRepository.GetAll();
            return PartialView(dealers);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            List<SelectListItem> Statues = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "فعال",
                    Value = Convert.ToInt32(Domain.Enums.Status.StatusTypes.Active).ToString(),
                },
                new SelectListItem
                {
                    Text="غیرفعال",
                    Value = Convert.ToInt32(Domain.Enums.Status.StatusTypes.Inactive).ToString(),
                },
                new SelectListItem
                {
                    Text = "تعلیق",
                    Value = Convert.ToInt32(Domain.Enums.Status.StatusTypes.Suspended).ToString()
                }
            };

            ViewBag.Cities = _cityRepository.GetAllForSelectBoxVM();
            ViewBag.Statues = Statues;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDealerVM model)
        {
            bool success = false;
            var message = ".عملیات ثبت با شکست مواجه شده است";
            var checkMessage = "";

            if (ModelState.IsValid)
            {
                try
                {
                    Dealer dealer = new Dealer()
                    {
                        Code = new Random().Next(1000, 8999),
                        Name = model.Name,
                        Status = Convert.ToInt32(model.Status),
                        CityId = model.CityId,
                        DealerNo= new Random().Next(1000, 9999),
                    };

                    bool result = _dealerRepository.Insert(dealer, out checkMessage);
                    _cityRepository.SaveChanges();

                    if (result)
                    {
                        success = true;
                        message = $"عملیات ثبت فروشنده {model.Name} موفقیت آمیز بود. ";
                    }
                    else
                    {
                        message = checkMessage;
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "خطای شکست عملیات ثبت : " + ex.Message;
                }

            }
            else
            {
                message = ".داده ورودی نامعتبر است";
            }

            return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });

        }
        #endregion

        #region Delete
        public ActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }

            DisplayDealerByIdVM dealer = _dealerRepository.GetById(id);

            if (dealer == null)
                return View();

            return PartialView(dealer);
        }

        [HttpPost]
        public ActionResult Delete(Update_DeleteDealerVM model)
        {
            bool success = false;
            var message = ".عملیات حذف با شکست مواجه شده است";
            var checkMessage = "";

            if (model.Id != Guid.Empty)
            {
                try
                {
                    var result = _dealerRepository.Delete(model.Id, out checkMessage);
                    _cityRepository.SaveChanges();

                    if (result)
                    {
                        success = true;
                        message = $"عملیات حذف فروشنده موفقیت آمیز بود. ";
                    }
                    else
                    {
                        message = checkMessage;
                    }

                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "خطای شکست عملیات ثبت : " + ex.Message;
                }

            }
            else
            {
                message = ".داده ورودی نامعتبر است";
            }

            return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });

        }
        #endregion

        #region Update
        public ActionResult Update(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }

            DisplayDealerByIdVM dealer = _dealerRepository.GetById(id);
           
            if (dealer == null)
                return View();

            List<SelectListItem> Statues = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "فعال",
                    Value = ((int)Domain.Enums.Status.StatusTypes.Active).ToString() ,
                },
                new SelectListItem
                {
                    Text="غیرفعال",
                    Value = ((int)Domain.Enums.Status.StatusTypes.Inactive).ToString(),
                },
                new SelectListItem
                {
                    Text = "تعلیق",
                    Value = ((int) Domain.Enums.Status.StatusTypes.Suspended).ToString(),
                }
            };

            ViewBag.Statues = Statues;
            return PartialView(dealer);
        }

        [HttpPost]
        public ActionResult Update(UpdateDealerVM model)
        {
            bool success = false;
            var message = ".عملیات ویرایش با شکست مواجه شده است";
            var checkMessage = "";

            if (model.Id != Guid.Empty)
            {
                try
                {
                    Dealer dealer = new Dealer()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Status = Convert.ToInt32(model.Status),
                    };

                    var result = _dealerRepository.Update(dealer, out checkMessage);
                    _dealerRepository.SaveChanges();

                    if (result)
                    {
                        success = true;
                        message = $"عملیات ویرایش فروشنده {dealer.Name} موفقیت آمیز بود. ";
                    }
                    else
                    {
                        message = checkMessage;
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    message = "خطای شکست عملیات ثبت : " + ex.Message;
                }

            }
            else
            {
                message = ".داده ورودی نامعتبر است";
            }

            return Json(new { success = success, message = message, JsonRequestBehavior.AllowGet });

        }
        #endregion
    }
}

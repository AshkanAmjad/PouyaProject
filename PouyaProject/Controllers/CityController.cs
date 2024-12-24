using Data.Context;
using Data.Repositories;
using Domain.Entities.Portal.Models;
using Domain.Interfaces;
using Domain.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PouyaProject.Controllers
{
    public class CityController : Controller
    {
        #region Constructor
        private readonly ICityRepository _cityRepository;
        PouyaContext _context = new PouyaContext();
        public CityController()
        {
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
        public ActionResult GetCities()
        {
            var cities = _cityRepository.GetAll();
            return PartialView(cities);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityVM model)
        {
            bool success = false;
            var message = ".عملیات ثبت با شکست مواجه شده است";
            var checkMessage = "";

            if (ModelState.IsValid)
            {
                try
                {
                    City city = new City()
                    {
                        Code = new Random().Next(1000, 9999),
                        Name = model.Name,
                    };

                    bool result = _cityRepository.Insert(city,out checkMessage);
                    _cityRepository.SaveChanges();

                    if (result) { 
                    success = true;
                    message = $"عملیات ثبت شهر {model.Name} موفقیت آمیز بود. ";
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

            City city = _cityRepository.GetById(id);
            if (city == null)
                return View();

            return PartialView(city);
        }

        [HttpPost]
        public ActionResult Delete(Update_DeleteCityVM model)
        {
            bool success = false;
            var message = ".عملیات حذف با شکست مواجه شده است";
            var checkMessage = "";

            if (model.Id != Guid.Empty)
            {
                try
                {
                    var result = _cityRepository.Delete(model.Id, out checkMessage);
                    _cityRepository.SaveChanges();

                    if (result)
                    {
                        success = true;
                        message = $"عملیات حذف شهر موفقیت آمیز بود. ";
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

            City city = _cityRepository.GetById(id);
            if (city == null)
                return View();

            return PartialView(city);
        }

        [HttpPost]
        public ActionResult Update(UpdateCityVM model)
        {
            bool success = false;
            var message = ".عملیات ویرایش با شکست مواجه شده است";
            var checkMessage = "";

            if (model.Id != Guid.Empty)
            {
                try
                {
                    City city = new City()
                    {
                        Id = model.Id,
                        Name = model.Name
                    };

                    var result = _cityRepository.Update(city,out checkMessage);
                    _cityRepository.SaveChanges();

                    if (result) { 
                    success = true;
                    message = $"عملیات ویرایش شهر {city.Name} موفقیت آمیز بود. ";}
                    else
                    {
                        message=checkMessage;
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
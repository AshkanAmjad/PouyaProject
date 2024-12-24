using Data.Context;
using Domain.Entities.Portal.Models;
using Domain.Interfaces;
using Domain.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        #region DB
        private readonly PouyaContext _context;
        public CityRepository(PouyaContext context)
        {
            _context = context;
        }
        #endregion
        public List<DisplayCitiesVM> GetAll()
        {
            return _context.Cities.Select(c => new DisplayCitiesVM
            {
                Code = c.Code.ToString(),
                Name = c.Name,
                Id = c.Id
            }).ToList();
        }

        public bool Delete(Guid id, out string message)
        {
            bool result = false;

            try
            {
                var city = _context.Cities.Find(id);
                _context.Cities.Remove(city);
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

        public City GetById(Guid id)
        {
            return _context.Cities.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Update(City city, out string message)
        {
            bool result = false;
            string checkMessage = "عملیات ویرایش موفقیت آمیز نبود.";

            try
            {
                if (Similarity(city, out checkMessage, "1"))
                {
                    message = checkMessage;
                    return false;
                }
                
                var initial = _context.Cities.Where(c => c.Id == city.Id)
                                             .FirstOrDefault();

                if (initial != null)
                {
                    initial.Name = city.Name;

                    _context.Cities.AddOrUpdate(initial);

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

        public bool Insert(City city, out string message)
        {
            bool result = false;
            string checkMessage = "";

            try
            {
                if (Similarity(city, out checkMessage, "0"))
                {
                    message = checkMessage;
                    return false;
                }

                _context.Cities.Add(city);
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

        public bool Similarity(City city, out string message, string type)
        {
            if (city == null)
            {
                message = "اطلاعات ناقص ارسال شده است.";
                return true;
            }

            bool result = false;
            string checkMessage = "";

            if (type == "0")
            {
                result = _context.Cities.Where(c => c.Name == city.Name ||
                                                    c.Code == city.Code)
                                        .Any();

            }
            else if (type == "1")
            {
                result = _context.Cities.Where(c => c.Id != city.Id &&
                                                    c.Name == city.Name)
                                        .Any();

            }

            if (result)
            {
                checkMessage = "نام یا کد ثبتی تکراری است.";
                result = true ;
            }

            message = checkMessage;
            return result;


        }

        public List<SelectListItem>  GetAllForSelectBoxVM()
        {
            using (PouyaContext context = new PouyaContext())
            {
                var cities = _context.Cities.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

                return cities;
            }            
            
        }

    }
}

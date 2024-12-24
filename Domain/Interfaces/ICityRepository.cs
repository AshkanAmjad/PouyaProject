using Domain.Entities.Portal.Models;
using Domain.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Interfaces
{
    public interface ICityRepository
    {
        List<DisplayCitiesVM> GetAll();
        List<SelectListItem> GetAllForSelectBoxVM();
        City GetById(Guid id);
        bool Insert(City city, out string message);
        bool Update(City city, out string message);
        bool Delete(Guid id, out string message);
        bool Similarity(City city, out string message, string type);
        void SaveChanges();

    }
}

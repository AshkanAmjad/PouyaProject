using Domain.Entities.Portal.Models;
using Domain.ViewModels.Dealer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDealerRepository
    {
        List<DisplayDealerVM> GetAll();
        bool Insert(Dealer dealer, out string message);
        bool Similarity(Dealer dealerr, out string message, string type);
        DisplayDealerByIdVM GetById(Guid id);
        bool Update(Dealer dealer, out string message);
        bool Delete(Guid id, out string message);
        void SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Dealer
{
    public class CreateDealerVM
    {
        public string Name { get; set; }
        public string Status {  get; set; }
        public Guid CityId { get; set; }
    }
}

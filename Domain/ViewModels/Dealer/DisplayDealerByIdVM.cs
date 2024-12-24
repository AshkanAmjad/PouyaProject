using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Dealer
{
    public class DisplayDealerByIdVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CityName {  get; set; }
        public int Status { get; set; }
    }
}

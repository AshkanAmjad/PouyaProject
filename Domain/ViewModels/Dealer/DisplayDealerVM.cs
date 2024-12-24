using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Dealer
{
    public class DisplayDealerVM
    {
        public Guid Id { get; set; }
        public string Code {  get; set; }
        public string DealorNo {  get; set; }
        public string CityName {  get; set; }
        public string Name { get; set; }
        public string Status {  get; set; }
    }
}

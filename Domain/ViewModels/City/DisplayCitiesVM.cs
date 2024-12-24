using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.City
{
    public class DisplayCitiesVM
    {
        public Guid Id { get; set; }
        public string Code {  get; set; }
        public string Name { get; set; }
    }
}

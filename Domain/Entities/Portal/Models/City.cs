using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Portal.Models
{
    public class City
    {
        #region Properties
        public Guid Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }
        #endregion

        #region Navigation
        public virtual Collection<Dealer> Dealers{ get; set; }
        #endregion

        #region Constructor
        public City()
        {
            Id= Guid.NewGuid();
        }
        #endregion
    }
}

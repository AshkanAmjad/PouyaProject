using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Portal.Models
{
    public class Dealer
    {
        #region Properties
        public Guid Id { get; set; }

        public int Code {  get; set; }

        public int DealerNo {  get; set; }

        public string Name { get; set; }

        public int Status {  get; set; }

        public Guid CityId { get; set; }
        #endregion

        #region Navigation
        public virtual City City { get; set; }
        #endregion

        #region Constructor
        public Dealer()
        {
            Id = Guid.NewGuid();
        }
        #endregion
    }
}

using Domain.Entities.Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Portal.Mapping
{
    public class CityMapping: EntityTypeConfiguration<City>
    {
        public CityMapping()
        {
            this.ToTable("Cities", "Portal");
            
            this.HasKey(k => k.Id);

            this.Property(p => p.Name).HasMaxLength(50)
                .IsRequired();

            this.Property(p => p.Code)
                .IsRequired();
        }


    }
}

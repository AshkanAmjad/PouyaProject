using Domain.Entities.Portal.Models;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Entities.Portal.Mapping
{
    public class DealerMapping: EntityTypeConfiguration<Dealer>
    {
        public DealerMapping()
        {
            this.ToTable("Dealers", "Portal");

            this.HasKey(k => k.Id);

            this.Property(p => p.DealerNo)
                .IsRequired();

            this.Property(p => p.Name)
                .HasMaxLength(50);

            this.HasRequired(p => p.City)
                .WithMany(p => p.Dealers)
                .HasForeignKey(p => p.CityId);
        }
    }
}

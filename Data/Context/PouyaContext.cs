using Domain.Entities.Portal.Mapping;
using Domain.Entities.Portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data.Context
{
    public class PouyaContext:DbContext
    {
        #region Constructor
        public PouyaContext() : base("PouyaProject_DB") { }
        #endregion

        #region Tables
        public DbSet<City> Cities { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        #endregion

        #region Fluent
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new DealerMapping());

            modelBuilder.Entity<Dealer>()
            .HasIndex(d => d.DealerNo)
            .IsUnique(); //Unique DealerNo

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }
}

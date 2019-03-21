using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NLayerStudent.DAL.Entities;

namespace NLayerStudent.DAL.EFC
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
 
        static MobileContext()
        {
            Database.SetInitializer<MobileContext>(new StoreDbInitializer());
        }
        public MobileContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
            db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
            db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
            db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
            db.SaveChanges();
        }
    }
}

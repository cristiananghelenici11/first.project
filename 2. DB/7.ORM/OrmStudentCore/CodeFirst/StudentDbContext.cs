using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{

    public class StudentDbContext : DbContext
    {
        private const string  conectionString = @"Data Source=MDDSK40062\SQLEXPRESS;Initial Catalog=StudentDemo;Integrated Security=True";
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conectionString);
        }
    }
}

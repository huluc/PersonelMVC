using PersonelMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonelMVC
{
    public class PersonelDbContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<User> Users { get; set; }

        public PersonelDbContext() : base("PersonelDbConStr")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Departmant)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmantId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
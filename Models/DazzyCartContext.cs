using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DazzyCart.Models
{
    public class DazzyCartContext : DbContext
    {
        public DazzyCartContext() : base("ConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Products> products { get; set; }
        public DbSet<User> user { get; set; }
        //public DbSet<Products> products { get; set; }
    }
}
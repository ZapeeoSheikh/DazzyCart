using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DazzyCart.Models
{
    public class DazzyCartContext : DbContext
    {
        public DazzyCartContext() : base("ConnectionString")
        {

        }
        public DbSet<Products> products { get; set; }
        public DbSet<User> user { get; set; }
        //public DbSet<Products> products { get; set; }
    }
}
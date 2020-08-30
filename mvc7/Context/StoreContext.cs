using muscshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace muscshop.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StoreContext>());

        }

        
        
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

    }

    
}
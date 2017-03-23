using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KaraokeBar.Models
{
    public class KaraokeBarEntities : DbContext
    {
        public KaraokeBarEntities() : base("KaraokeBar"){ }
        
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
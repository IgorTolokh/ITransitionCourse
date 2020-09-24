using Store.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Collection> Collections{ get; set; }
        public DbSet<Item> Items { get; set; }
    }
}

using OnlineTicketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketApp.DAL
{
   public class TicketsDbContext : DbContext
    {
        public TicketsDbContext() : base("ticketDb")
        {
            Cities = new DbSet<City, int>(_Connection);
            Countries = new DbSet<Country, int>(_Connection);
        }

      
        public DbSet<City,int> Cities { get; set; }

        public DbSet<Country, int> Countries { get; set; }

    }
}

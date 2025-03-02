using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class HotelContext:DbContext
    {
        static HotelContext()
        {
            var ensureDLLIsCopied = SqlProviderServices.Instance;
        }
        public HotelContext() : base("Conn")
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Frontend> Frontends { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
    }
}

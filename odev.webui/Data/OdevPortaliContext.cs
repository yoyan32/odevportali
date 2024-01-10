using Microsoft.EntityFrameworkCore;
using OdevPortali.Models;

namespace odev.webui.Data
{
    public class OdevPortaliContext : DbContext
    {
        public OdevPortaliContext()
        {
        }

        public OdevPortaliContext(DbContextOptions<OdevPortaliContext> options)
            : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Odevs> Odevler { get; set; }
    }

        public class Odevs
        {
        
       
        public string Ad { get; set; }
     
        }
}

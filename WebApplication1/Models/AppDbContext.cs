using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BannerItem> BannerItems { get; set; }
        public DbSet<ContactFormModel> Messag { get; set; }

        public DbSet<TourOffer> tourOffers { get; set; }


    }
}


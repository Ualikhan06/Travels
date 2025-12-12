using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class DbUser : DbContext
    {
        public DbUser()
        {
        }


        public DbUser(DbContextOptions<DbUser> options)
            : base(options)
        {
        }

        public DbSet<UserRegistrationModel> UserInfo { get; set; }


    }
}
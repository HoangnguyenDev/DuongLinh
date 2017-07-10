using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MainProject.Models;

namespace MainProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MainProject.Models.BookCategory> BookCategory { get; set; }
        public DbSet<MainProject.Models.BookChappter> BookChappter { get; set; }
        public DbSet<MainProject.Models.HistoryOfChappter> HistoryOfChappter { get; set; }
        public DbSet<MainProject.Models.HistoryofRedingBook> HistoryofRedingBook { get; set; }
        public DbSet<MainProject.Models.Message> Message { get; set; }
        public DbSet<MainProject.Models.Notifications> Notifications { get; set; }
    }
}

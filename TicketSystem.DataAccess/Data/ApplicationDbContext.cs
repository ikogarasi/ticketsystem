using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;
using TicketSystem.Models.ViewModels;

namespace TicketSystem.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StationModel> Stations { get; set; }
        public DbSet<RouteModel> Routes { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BoardingPassModel> BoardingPasses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder)
        }
    }
}
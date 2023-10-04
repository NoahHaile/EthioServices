using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EthioServices.Models;

namespace EthioServices.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<EthioServices.Models.Jobs>? Jobs { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; } 
        public DbSet<EthioServices.Models.Talent>? Talent { get; set; }
        public DbSet<EthioServices.Models.Client>? Client { get; set; }
        public DbSet<EthioServices.Models.Message>? Message { get; set; }
        public DbSet<EthioServices.Models.Balance>? Balance { get; set; }
    }
}
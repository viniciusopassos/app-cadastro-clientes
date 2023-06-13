using ClienteApi.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace projeto_MVC_Angular.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } 
    }
}
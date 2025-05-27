using Microsoft.EntityFrameworkCore;
using HomeRentAppShared.Models;
namespace HomeRentAppApi.Data
{
    public class HomeRentDbContext : DbContext
    {
        public HomeRentDbContext(DbContextOptions<HomeRentDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}

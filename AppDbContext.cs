using AppWebMonolitico.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebMonolitico
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Clase> Clase { get; set; }

    }
}

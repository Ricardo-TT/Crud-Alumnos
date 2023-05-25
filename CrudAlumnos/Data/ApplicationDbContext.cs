using CrudAlumnos.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAlumnos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Alumno> Alumno { get; set; }

        public DbSet<Grado> Grado { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
namespace L01P022021AR601.Models

{
    public class db_notasDbContext: DbContext
    {
        public db_notasDbContext(DbContextOptions options) : base(options)

        { }

        public DbSet<materias> materias { get; set; }
        public DbSet<facultades> facultades { get; set; }
        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<alumnos> alumnos { get; set; }
    }
}

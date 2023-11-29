using Microsoft.EntityFrameworkCore;
using CCVLab.Models;
using System.Collections.Generic;

namespace CCVLab.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<CCVLab.Models.Paciente> Proyecto { get; set; }
        
    }
}

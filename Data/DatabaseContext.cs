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
        public DbSet<CCVLab.Models.Usuario> Usuarios { get; set; }
        public DbSet<CCVLab.Models.Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Relación de Usuario y Rol
            modelBuilder.Entity<UsuarioRol>()
                .HasKey(ur => new { ur.UsuarioID, ur.RolID });

            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRol)
                .HasForeignKey(ur => ur.UsuarioID);

            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.UsuarioRol)
                .HasForeignKey(ur => ur.RolID);
        }
    }
}

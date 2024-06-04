using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi93.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options) { }

        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Noemi",
                    User = "Usuario",
                    Password = "123",
                    FkRol = 1, //Aquí debes poner el rol correspondiente 

                }
                );

            //Insertar en la tabla roles
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                });
        }

    }
}

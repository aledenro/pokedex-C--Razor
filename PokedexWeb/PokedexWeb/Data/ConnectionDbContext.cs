using Microsoft.EntityFrameworkCore;
using PokedexWeb.Models;

namespace PokedexWeb.Data
{
    public class ConnectionDbContext : DbContext
    {
        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options) : base(options) { }

        public DbSet<TipoModel> Tipo_G7 { get; set; }
        public DbSet<HabilidadModel> Habilidad_G7 { get; set; }
        public DbSet<PokemonModel> Pokemon_G7 { get; set; }
        public DbSet<PokemonTipoModel> Pokemon_Tipo_G7 { get; set; }
        public DbSet<PokemonHabilidadModel> Pokemon_Habilidad_G7 { get; set; }
        public DbSet<UsuarioModel> Usuario_G7 { get; set; }
        public DbSet<RolModel> Rol_G7 { get; set; }
        public DbSet<UsuarioRolModel> Usuario_Rol_G7 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoModel>().ToTable("Tipo_G7")
                .HasMany(t => t.PokemonTipos)
                .WithOne(pt => pt.Tipo)
                .HasForeignKey(pt => pt.id_tipo); 

            modelBuilder.Entity<HabilidadModel>().ToTable("Habilidad_G7")
                .HasMany(h => h.PokemonHabilidades)
                .WithOne(ph => ph.Habilidad)
                .HasForeignKey(ph => ph.id_habilidad);

            modelBuilder.Entity<PokemonModel>().ToTable("Pokemon_G7")
                .HasMany(p => p.PokemonTipos)
                .WithOne(pt => pt.Pokemon)
                .HasForeignKey(pt => pt.id_pokemon);

            modelBuilder.Entity<PokemonModel>().ToTable("Pokemon_G7")
                .HasMany(p => p.PokemonHabilidades)
                .WithOne(ph => ph.Pokemon)
                .HasForeignKey(ph => ph.id_pokemon);

            modelBuilder.Entity<PokemonTipoModel>().ToTable("Pokemon_Tipo_G7");

            modelBuilder.Entity<PokemonHabilidadModel>().ToTable("Pokemon_Habilidad_G7");

            modelBuilder.Entity<UsuarioModel>()
                 .ToTable("Usuario_G7")
                 .HasKey(u => u.id_usuario);

            // Configuración de la tabla Rol
            modelBuilder.Entity<RolModel>()
                .ToTable("Rol_G7")
                .HasKey(r => r.id_rol);

            // Configuración de la tabla UsuarioRol
            modelBuilder.Entity<UsuarioRolModel>()
                .ToTable("Usuario_Rol_G7")
                .HasKey(ur => ur.id_usuario_rol);

            modelBuilder.Entity<UsuarioRolModel>()
                .HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRoles)
                .HasForeignKey(ur => ur.id_usuario);

            modelBuilder.Entity<UsuarioRolModel>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(ur => ur.id_rol);

        }

    }
}

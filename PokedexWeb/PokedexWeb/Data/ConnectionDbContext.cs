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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoModel>().ToTable("Tipo_G7")
                .HasMany(t => t.PokemonTipos)
                .WithOne(pt => pt.Tipo)
                .HasForeignKey(pt => pt.id_tipo); 
            modelBuilder.Entity<HabilidadModel>().ToTable("Habilidad_G7");
            modelBuilder.Entity<PokemonModel>().ToTable("Pokemon_G7")
                .HasMany(p => p.PokemonTipos)
                .WithOne(pt => pt.Pokemon)
                .HasForeignKey(pt => pt.id_pokemon);
            modelBuilder.Entity<PokemonTipoModel>().ToTable("Pokemon_Tipo_G7");
            modelBuilder.Entity<PokemonHabilidadModel>().ToTable("Pokemon_Habilidad_G7");
        }

    }
}

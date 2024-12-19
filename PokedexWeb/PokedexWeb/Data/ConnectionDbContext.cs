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
        public DbSet<RetoModel> Reto_G7 { get; set; }
        public DbSet<EnfermeriaModel> Enfermeria_G7 { get; set; }
        public DbSet<UsuarioPokemonModel> UsuarioPokemon_G7 { get; set; }
        public DbSet<ChatModel> Chat_G7 { get; set; }
        public DbSet<MensajeModel>Mensaje_G7 { get; set; }

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

            modelBuilder.Entity<RolModel>()
                .ToTable("Rol_G7")
                .HasKey(r => r.id_rol);

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

            modelBuilder.Entity<RetoModel>()
                .ToTable("Reto_G7")
                .HasKey(r => r.id_reto);

            modelBuilder.Entity<RetoModel>()
                .HasOne(r => r.Retador)
                .WithMany(u => u.RetoRetador)
                .HasForeignKey(r => r.id_retador);

            modelBuilder.Entity<RetoModel>()
                .HasOne(r => r.Contendiente)
                .WithMany(u => u.RetoContendiente)
                .HasForeignKey(r => r.id_contendiente);

            modelBuilder.Entity<EnfermeriaModel>()
            .ToTable("Detalle_Enfermeria_G7")
            .HasKey(d => d.id_detalle_enfermeria);

            modelBuilder.Entity<EnfermeriaModel>()
                .HasOne(d => d.Entrenador)
                .WithMany(u => u.EnfermeriaEntrenador)
                .HasForeignKey(d => d.id_entrenador);

            modelBuilder.Entity<EnfermeriaModel>()
               .HasOne(d => d.Enfermero)
               .WithMany(u => u.EnfermeriaEnfermero)
               .HasForeignKey(d => d.id_enfermero);

            modelBuilder.Entity<EnfermeriaModel>()
                .HasOne(d => d.Pokemon)
                .WithMany(p => p.PokemonEnfermeria)
                .HasForeignKey(d => d.id_pokemon);

            modelBuilder.Entity<UsuarioPokemonModel>()
                .ToTable("Usuario_Pokemon_G7")
                .HasKey(up => up.id_usuario_pokemon);

            modelBuilder.Entity<UsuarioPokemonModel>()
                .HasOne(up => up.pokemon)
                .WithMany(p => p.PokemonUsuario)
                .HasForeignKey(up => up.id_pokemon);

            modelBuilder.Entity<UsuarioPokemonModel>()
                .HasOne(up => up.usuario)
                .WithMany(u => u.UsuarioPokemons)
                .HasForeignKey(up => up.id_usuario);

            modelBuilder.Entity<ChatModel>()
                .ToTable("Chat_G7")
                .HasKey(c => c.id_chat);

            modelBuilder.Entity<ChatModel>()
                .HasOne(c  => c.Usuario1)
                .WithMany(u => u.EnviaChat)
                .HasForeignKey(c => c.id_usuario1);

            modelBuilder.Entity<ChatModel>()
                .HasOne(c => c.Usuario2)
                .WithMany(u => u.RecibeChat)
                .HasForeignKey(c => c.id_usuario2);

            modelBuilder.Entity<MensajeModel>()
                .ToTable("Mensaje_G7")
                .HasKey(m => m.id_mensaje);

            modelBuilder.Entity<MensajeModel>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.MensajesChat)
                .HasForeignKey(m => m.id_chat);
        }

    }
}

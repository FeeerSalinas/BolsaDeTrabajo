using BolsaDeTrabajo.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeTrabajo.Data
{
    public class BolsaDeTrabajoContext : DbContext
    {
        public BolsaDeTrabajoContext(DbContextOptions<BolsaDeTrabajoContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<DocumentosAspirante> DocumentosAspirantes { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }
        public DbSet<ExperienciaLaboral> ExperienciasLaborales { get; set; }
        public DbSet<FormacionAcademica> FormacionesAcademicas { get; set; }
        public DbSet<Certificacion> Certificaciones { get; set; }
        public DbSet<Logro> Logros { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<AplicacionOferta> AplicacionesOferta { get; set; }
        public DbSet<OfertaLaboral> OfertasLaborales { get; set; }

        public DbSet<Publicacion> Publicaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Direccion>().ToTable("Direccion");
            modelBuilder.Entity<Contacto>().ToTable("Contacto");
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<Aspirante>().ToTable("Aspirante");
            modelBuilder.Entity<DocumentosAspirante>().ToTable("Documentos_Aspirante");
            modelBuilder.Entity<Recomendacion>().ToTable("Recomendaciones");
            modelBuilder.Entity<Habilidad>().ToTable("Habilidades");
            modelBuilder.Entity<ExperienciaLaboral>().ToTable("Experiencia_Laboral");
            modelBuilder.Entity<FormacionAcademica>().ToTable("Formacion_Academica");
            modelBuilder.Entity<Certificacion>().ToTable("Certificaciones");
            modelBuilder.Entity<Logro>().ToTable("Logros");
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            modelBuilder.Entity<Examen>().ToTable("Examenes");
            modelBuilder.Entity<Idioma>().ToTable("Idiomas");
            modelBuilder.Entity<AplicacionOferta>().ToTable("AplicacionesOferta");
            modelBuilder.Entity<OfertaLaboral>().ToTable("Oferta_laboral");
            modelBuilder.Entity<Publicacion>().ToTable("Publicaciones");

            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaRegistro)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            modelBuilder.Entity<Direccion>().HasKey(d => d.IdUsuario);
            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.Usuario)
                .WithOne()
                .HasForeignKey<Direccion>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Direccion>()
                .Property(d => d.DetalleDireccion)
                .HasColumnName("direccion");

            modelBuilder.Entity<Contacto>().HasKey(c => c.IdUsuario);
            modelBuilder.Entity<Contacto>()
                .HasOne(c => c.Usuario)
                .WithOne()
                .HasForeignKey<Contacto>(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Empresa>().HasKey(e => e.IdEmpresa);
            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aspirante>().HasKey(a => a.IdAspirante);
            modelBuilder.Entity<Aspirante>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DocumentosAspirante>().HasKey(d => d.IdAspirante);
            modelBuilder.Entity<DocumentosAspirante>()
                .HasOne(d => d.Aspirante)
                .WithOne()
                .HasForeignKey<DocumentosAspirante>(d => d.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Certificacion>().HasKey(c => c.IdCertificacion);
            modelBuilder.Entity<Certificacion>()
                .HasOne(c => c.Aspirante)
                .WithMany()
                .HasForeignKey(c => c.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recomendacion>().HasKey(r => r.IdRecomendacion);
            modelBuilder.Entity<Recomendacion>()
                .HasOne(r => r.Aspirante)
                .WithMany()
                .HasForeignKey(r => r.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Habilidad>().HasKey(h => h.IdHabilidad);
            modelBuilder.Entity<Habilidad>()
                .HasOne(h => h.Aspirante)
                .WithMany()
                .HasForeignKey(h => h.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExperienciaLaboral>().HasKey(e => e.IdExperiencia);
            modelBuilder.Entity<ExperienciaLaboral>()
                .HasOne(e => e.Aspirante)
                .WithMany()
                .HasForeignKey(e => e.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FormacionAcademica>().HasKey(f => f.IdFormacion);
            modelBuilder.Entity<FormacionAcademica>()
                .HasOne(f => f.Aspirante)
                .WithMany()
                .HasForeignKey(f => f.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evento>().HasKey(e => e.IdEvento);
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Aspirante)
                .WithMany()
                .HasForeignKey(e => e.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Examen>().HasKey(e => e.IdExamen);
            modelBuilder.Entity<Examen>()
                .HasOne(e => e.Aspirante)
                .WithMany()
                .HasForeignKey(e => e.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Idioma>().HasKey(i => i.IdIdioma);
            modelBuilder.Entity<Idioma>()
                .HasOne(i => i.Aspirante)
                .WithMany()
                .HasForeignKey(i => i.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Logro>().HasKey(l => l.IdLogro);
            modelBuilder.Entity<Logro>()
                .HasOne(l => l.Aspirante)
                .WithMany()
                .HasForeignKey(l => l.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OfertaLaboral>().HasKey(o => o.IdOferta);
            modelBuilder.Entity<OfertaLaboral>()
                .HasOne(o => o.Empresa)
                .WithMany()
                .HasForeignKey(o => o.IdEmpresa)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AplicacionOferta>().HasKey(a => a.IdAplicacion);
            modelBuilder.Entity<AplicacionOferta>()
                .HasOne(a => a.Aspirante)
                .WithMany()
                .HasForeignKey(a => a.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AplicacionOferta>()
                .HasOne(a => a.Oferta)
                .WithMany()
                .HasForeignKey(a => a.IdOferta)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Publicacion>().HasKey(p => p.IdPublicacion);
            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Aspirante)
                .WithMany()
                .HasForeignKey(p => p.IdAspirante)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

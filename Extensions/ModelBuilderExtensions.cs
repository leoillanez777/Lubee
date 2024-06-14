using Lubee.Models;
using Microsoft.EntityFrameworkCore;

namespace Lubee.Extensions;

public static class ModelBuilderExtensions {
  public static void Clasificados(this ModelBuilder modelBuilder) {    
    modelBuilder.Entity<Clasificado>().HasKey(t => t.Id);
    
    modelBuilder.Entity<Clasificado>()
      .HasMany(c => c.ClasificadoImagen)
      .WithOne(ci => ci.Clasificado)
      .HasForeignKey(ci => ci.ClasificadoId)
      .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Clasificado>()
      .HasOne(c => c.TipoPropiedad)
      .WithMany(tp => tp.Clasificados)
      .HasForeignKey(c => c.TipoPropiedadId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Clasificado>()
      .HasOne(c => c.TipoOperacion)
      .WithMany(to => to.Clasificados)
      .HasForeignKey(c => c.TipoOperacionId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Clasificado>()
      .Property(c => c.Ubicacion)
      .HasColumnType("geography")
      .IsRequired(false);

    modelBuilder.Entity<Clasificado>()
      .Property(c => c.Descripcion)
      .HasMaxLength(200);
  }

  public static void TipoPropiedades(this ModelBuilder modelBuilder) {    
    modelBuilder.Entity<TipoPropiedad>().HasKey(tp => tp.Id);
    
    modelBuilder.Entity<TipoPropiedad>()
      .HasMany(tp => tp.Clasificados)
      .WithOne(c => c.TipoPropiedad)
      .HasForeignKey(c => c.TipoPropiedadId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<TipoPropiedad>()
      .Property(tp => tp.Nombre)
      .IsRequired()
      .HasMaxLength(200);
  }

  public static void TipoOperacion(this ModelBuilder modelBuilder) {    
    modelBuilder.Entity<TipoOperacion>().HasKey(to => to.Id);

    modelBuilder.Entity<TipoOperacion>()
      .HasMany(to => to.Clasificados)
      .WithOne(c => c.TipoOperacion)
      .HasForeignKey(c => c.TipoOperacionId)
      .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<TipoOperacion>()
      .Property(to => to.Nombre)
      .IsRequired()
      .HasMaxLength(200);
  }

  public static void ClasificadoImagen(this ModelBuilder modelBuilder) {
    modelBuilder.Entity<ClasificadoImagen>().HasKey(ci => ci.Id);

    modelBuilder.Entity<ClasificadoImagen>()
      .HasOne(ci => ci.Clasificado)
      .WithMany(c => c.ClasificadoImagen)
      .HasForeignKey(ci => ci.ClasificadoId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
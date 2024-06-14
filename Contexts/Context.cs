using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Lubee.Models;

namespace Lubee.Contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options) {
  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Clasificados();
    modelBuilder.TipoPropiedades();
    modelBuilder.TipoOperacion();
    modelBuilder.ClasificadoImagen();
  }

  #region Tables
  public DbSet<Clasificado> Clasificados { get; set; }
  public DbSet<TipoPropiedad> TiposPropiedades { get; set; }
  public DbSet<TipoOperacion> TiposOperaciones { get; set; }
  public DbSet<ClasificadoImagen> ClasificadoImagenes { get; set; }
  #endregion
}
using NetTopologySuite.Geometries;

namespace Lubee.Models;

public class Clasificado {
  public int Id { get; set;}
  public int TipoPropiedadId { get; set; }
  public TipoPropiedad TipoPropiedad { get; set; } = null!;
  public int TipoOperacionId { get; set; }
  public TipoOperacion TipoOperacion { get; set; } = null!;
  public string Descripcion { get; set; } = null!;
  public int Ambientes { get; set; }
  public int M2 { get; set; }
  public int Antiguedad { get; set; }
  public string Direccion { get; set; } = null!;
  public Point? Ubicacion { get; set; }
  public virtual ICollection<ClasificadoImagen> ClasificadoImagen { get; set; } = [];
}
namespace Lubee.Models;

public class ClasificadoImagen {
  public int Id { get; set;}
  public int ClasificadoId { get; set;}
  public Clasificado Clasificado { get; set;} = null!;
  public byte[] Imagen { get; set; } = null!;
  public string Mime { get; set; } = null!;
}
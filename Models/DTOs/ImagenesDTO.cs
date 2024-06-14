namespace Lubee.Models.DTOs;

public class ImagenesDTO {
  public int Id { get; set; }
  public int ClasificadoId { get; set;}
  public byte[] Imagen { get; set; } = null!;
  public string Mime { get; set; } = null!;
  public string ImagenBase64 => Convert.ToBase64String(Imagen);
}
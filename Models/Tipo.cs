namespace Lubee.Models;

public class Tipo {
  public int Id { get; set; }
  public string Nombre { get; set; } = null!;

  public virtual ICollection<Clasificado> Clasificados { get; set; } = [];
}
using Newtonsoft.Json;

namespace Lubee.Models.DTOs;

public class ClasificadoDTO {
  [JsonProperty("id")]
  public int Id { get; set; }

  [JsonProperty("tipoPropiedadId")]
  public int TipoPropiedadId { get; set; }

  [JsonProperty("tipoPropiedad")]
  public TipoDTO? TipoPropiedad { get; set; }

  [JsonProperty("tipoOperacionId")]
  public int TipoOperacionId { get; set; }

  [JsonProperty("tipoOperacion")]
  public TipoDTO? TipoOperacion { get; set; }
  
  [JsonProperty("descripcion")]
  public string Descripcion { get; set; } = null!;
  public int Ambientes { get; set; }
  public int M2 { get; set; }
  public int Antiguedad { get; set; }
  public Address? Ubicacion { get; set; }
  public List<ImagenesDTO>? Imagenes { get; set; }
}

public class Address {
  public string Direccion { get; set; } = null!;
  public double Latitud { get; set; }
  public double Longitud { get; set; }
}
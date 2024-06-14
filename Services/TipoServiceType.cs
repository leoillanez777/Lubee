using System.ComponentModel.DataAnnotations;

namespace Lubee.Services;

public enum TipoServiceType {
  
  [Display(Name = "Operación")]
  TipoOperacion,
  [Display(Name = "Propiedad")]
  TipoPropiedad
}
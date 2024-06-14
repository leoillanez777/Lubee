using System.Security.Cryptography;
using Lubee.Models;
using Lubee.Services.Interfaces;

namespace Lubee.Services;

public class TiposFactory(IServiceProvider serviceProvider) : ITiposFactory {
  private readonly IServiceProvider serviceProvider = serviceProvider;

  public ITipos Create(TipoServiceType serviceType) {
    return serviceType switch {
      TipoServiceType.TipoOperacion => serviceProvider.GetRequiredService<TipoOperacionService>(),
      TipoServiceType.TipoPropiedad => serviceProvider.GetRequiredService<TipoPropiedadService>(),
      _ => throw new ArgumentException("Servicio no válido", nameof(serviceType)),
    };
  }
}
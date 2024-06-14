namespace Lubee.Services.Interfaces;

public interface ITiposFactory {
  ITipos Create(TipoServiceType serviceType);
}
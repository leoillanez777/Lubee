using Lubee.Models.DTOs;
using Lubee.Services;
using Lubee.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubee.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class TiposController(ITiposFactory tiposFactory) : ControllerBase {
  private readonly ITiposFactory tiposFactory = tiposFactory;

  private ITipos GetTiposService(TipoServiceType serviceType) {
    return tiposFactory.Create(serviceType);
  }

  [HttpGet]
  public async Task<ResponseDTO<List<TipoDTO>>> GetTipos(TipoServiceType serviceType) {
    var tipoService = GetTiposService(serviceType);
    return await tipoService.GetAll();
  }

  [HttpGet("{id}")]
  public async Task<ResponseDTO<TipoDTO>> GetTipoPorId(int id, TipoServiceType serviceType) {
    var tipoService = GetTiposService(serviceType);
    return await tipoService.GetTipo(id);
  }

  [HttpPost]
  public async Task<ResponseDTO<TipoDTO>> SaveData(TipoDTO data, TipoServiceType serviceType) {
    var tipoService = GetTiposService(serviceType);
    return await tipoService.Post(data);
  }

  [HttpDelete]
  public async Task<ResponseDTO<bool>> Delete(int id, TipoServiceType serviceType) {
    var tipoService = GetTiposService(serviceType);
    return await tipoService.Delete(id);
  }
}
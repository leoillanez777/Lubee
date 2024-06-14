using Lubee.Models.DTOs;
using Lubee.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubee.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class ClasificadosController(IClasificado clasificado) : ControllerBase {
  private readonly IClasificado clasificado = clasificado;

  [HttpGet]
  public async Task<ResponseDTO<List<ClasificadoDTO>>> GetAll() {
    return await clasificado.GetAll();
  }

  [HttpGet("{id}")]
  public async Task<ResponseDTO<ClasificadoDTO>> GetClasificado(int id) {
    return await clasificado.GetClasificado(id);
  }

  [HttpPost]
  public async Task<ResponseDTO<ClasificadoDTO>> SaveData(ClasificadoDTO data) {
    return await clasificado.PostClasificado(data);
  }

  [HttpDelete("{id}")]
  public async Task<ResponseDTO<bool>> Delete(int id) {
    return await clasificado.DeleteClasificado(id);
  }
}
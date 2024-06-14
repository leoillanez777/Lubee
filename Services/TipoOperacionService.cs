using AutoMapper;
using Lubee.Contexts;
using Lubee.Models;
using Lubee.Models.DTOs;
using Lubee.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lubee.Services;

public class TipoOperacionService(Context context, IMapper mapper) : ITipos {
  private readonly Context context = context;
  private readonly IMapper mapper = mapper;

  public async Task<ResponseDTO<List<TipoDTO>>> GetAll() {
    var response = new ResponseDTO<List<TipoDTO>> { Success = false };
    try {
      var data = await context.TiposOperaciones.ToListAsync();
      var tipos = mapper.Map<List<TipoDTO>>(data);
      response.Result = tipos;
      response.Success = true;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<TipoDTO>> GetTipo(int id) {
    var response = new ResponseDTO<TipoDTO> { Success = false };
    try {
      var data = await context.TiposOperaciones.FindAsync(id);
      var tipo = mapper.Map<TipoDTO>(data);
      response.Result = tipo;
      response.Success = true;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<TipoDTO>> Post(TipoDTO data) {
    var response = new ResponseDTO<TipoDTO> { Success = false };
    try {
      var tipo = mapper.Map<TipoOperacion>(data);
      if (tipo.Id == 0) {
        context.Add(tipo);
      }
      else {
        context.Update(tipo);
      }

      await context.SaveChangesAsync();
      response.Success = true;
      data.Id = tipo.Id;
      response.Result = data;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<bool>> Delete(int id) {
    var response = new ResponseDTO<bool> { Success = false };
    try {
      TipoOperacion tipoToDelete = new() { Id = id };

      context.Remove(tipoToDelete);
      await context.SaveChangesAsync();
      response.Success = response.Result = true;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }
}
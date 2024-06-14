using AutoMapper;
using Lubee.Contexts;
using Lubee.Models;
using Lubee.Models.DTOs;
using Lubee.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lubee.Services;

public class ClasificadoService(Context context, IMapper mapper): IClasificado {
  private readonly Context context = context;
  private readonly IMapper mapper = mapper;
  public async Task<ResponseDTO<List<ClasificadoDTO>>> GetAll() {
    var response = new ResponseDTO<List<ClasificadoDTO>> { Success = false };
    try {
      var data = await context.Clasificados
        .Include(c => c.TipoOperacion)
        .Include(c => c.TipoPropiedad)
        .Include(c => c.ClasificadoImagen)
        .ToListAsync();
      var clasificados = mapper.Map<List<ClasificadoDTO>>(data);
      response.Result = clasificados;
      response.Success = true;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<ClasificadoDTO>> GetClasificado(int id) {
    var response = new ResponseDTO<ClasificadoDTO> { Success = false };
    try {
      var data = await context.Clasificados
        .Include(c => c.TipoOperacion)
        .Include(c => c.TipoPropiedad)
        .Include(c => c.ClasificadoImagen)
        .FirstOrDefaultAsync(c => c.Id == id);
      if (data == null) {
        response.Message = "Clasificado no encontrado";
      }
      else {
        var clasificado = mapper.Map<ClasificadoDTO>(data);
        response.Result = clasificado;
        response.Success = true;
      }
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<ClasificadoDTO>> PostClasificado(ClasificadoDTO data) {
    var response = new ResponseDTO<ClasificadoDTO> { Success = false };
    using var dbTransaction = context.Database.BeginTransaction();
    try {
      var clasificado = mapper.Map<Clasificado>(data);
      clasificado.TipoPropiedad = null!;
      clasificado.TipoOperacion = null!;
      bool nuevo = false;
      if (clasificado.Id == 0) {
        context.Add(clasificado);
        nuevo = true;
      }
      else {
        context.Update(clasificado);
      }
      await context.SaveChangesAsync();
      await dbTransaction.CommitAsync();

      if (nuevo) {
        data.Id = clasificado.Id;
        var tipoOperacion = await context.TiposOperaciones.FindAsync(clasificado.TipoOperacionId);
        data.TipoOperacion = new TipoDTO { Id = clasificado.TipoOperacionId, Nombre = tipoOperacion?.Nombre ?? "" };
        var tipoPropiedad = await context.TiposPropiedades.FindAsync(clasificado.TipoPropiedadId);
        data.TipoPropiedad = new TipoDTO { Id = clasificado.TipoPropiedadId, Nombre = tipoPropiedad?.Nombre ?? "" };
      }
      response.Success = true;
      response.Result = data;
      response.Message = $"Nº Clasificado: {clasificado.Id}";
    }
    catch (Exception ex) {
      await dbTransaction.RollbackAsync();
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<bool>> DeleteClasificado(int id)
  {
    var response = new ResponseDTO<bool> { Success = false };
    try {
      Clasificado clasificadoToDelete = new() { Id = id };

      context.Remove(clasificadoToDelete);
      await context.SaveChangesAsync();
      response.Success = response.Result = true;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

}
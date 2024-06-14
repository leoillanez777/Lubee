using AutoMapper;
using Lubee.Contexts;
using Lubee.Models;
using Lubee.Models.DTOs;
using Lubee.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lubee.Services;

public class ImagenesService(Context context, IMapper mapper): IImagenes {
  private readonly Context context = context;
  private readonly IMapper mapper = mapper;

  public async Task<ResponseDTO<List<ImagenesDTO>>> GetImagenes(int clasificadoId) {
    var response = new ResponseDTO<List<ImagenesDTO>> { Success = false };
    try {
      var data = await context.ClasificadoImagenes
        .Include(c => c.Clasificado)
        .Where(ci => ci.ClasificadoId == clasificadoId).ToListAsync();
      
      var imagenes = mapper.Map<List<ImagenesDTO>>(data);
      response.Result = imagenes;
      response.Success = true;
      
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<List<ImagenesDTO>>> Post(List<ImagenesDTO> data) {
    var response = new ResponseDTO<List<ImagenesDTO>> { Success = false };
    using var dbTransaction = context.Database.BeginTransaction();
    try {
      var clasificadoImagen = mapper.Map<List<ClasificadoImagen>>(data);
      foreach (var img in clasificadoImagen) {
        if (img.Id == 0) {
          context.Add(img);
        }
        else {
          context.Update(img);
        }
      }
      await context.SaveChangesAsync();
      await dbTransaction.CommitAsync();

      response.Success = true;
      response.Result = data;
    }
    catch (Exception ex) {
      await dbTransaction.RollbackAsync();
      response.Message = ex.Message;
    }
    return response;
  }

  public async Task<ResponseDTO<bool>> Delete(int id)
  {
    var response = new ResponseDTO<bool> { Success = false };
    try {
      ClasificadoImagen imagenToDelete = new() { Id = id };

      context.Remove(imagenToDelete);
      await context.SaveChangesAsync();
      response.Success = response.Result = true;
    }
    catch (Exception ex) {
      response.Message = ex.Message;
    }
    return response;
  }

  public byte[] GetBytes(IFormFile file) {
    long length = file.Length;
    using var fileStream = file.OpenReadStream();
    byte[] bytes = new byte[length];
    fileStream.Read(bytes, 0, (int)file.Length);
    return bytes;
  }
}
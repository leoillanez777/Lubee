using Lubee.Models.DTOs;

namespace Lubee.Services.Interfaces;

public interface IImagenes {
  Task<ResponseDTO<List<ImagenesDTO>>> GetImagenes(int clasificadoId);
  Task<ResponseDTO<List<ImagenesDTO>>> Post(List<ImagenesDTO> data);
  Task<ResponseDTO<bool>> Delete(int id);

  byte[] GetBytes(IFormFile file);
}
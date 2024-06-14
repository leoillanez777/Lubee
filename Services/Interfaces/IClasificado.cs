using Lubee.Models.DTOs;

namespace Lubee.Services.Interfaces;

public interface IClasificado {
  Task<ResponseDTO<ClasificadoDTO>> GetClasificado(int id);
  Task<ResponseDTO<List<ClasificadoDTO>>> GetAll();
  Task<ResponseDTO<ClasificadoDTO>> PostClasificado(ClasificadoDTO data);
  Task<ResponseDTO<bool>> DeleteClasificado(int id);
}
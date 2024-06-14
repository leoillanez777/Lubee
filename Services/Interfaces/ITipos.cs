using Lubee.Models.DTOs;

namespace Lubee.Services.Interfaces;

public interface ITipos {
  Task<ResponseDTO<TipoDTO>> GetTipo(int id);
  Task<ResponseDTO<List<TipoDTO>>> GetAll();
  Task<ResponseDTO<TipoDTO>> Post(TipoDTO data);
  Task<ResponseDTO<bool>> Delete(int id);
}
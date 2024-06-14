using Lubee.Models.DTOs;
using Lubee.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lubee.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class ImagenesController(IImagenes imagenes) : ControllerBase {
  private readonly IImagenes imagenes = imagenes;

  [HttpGet("{id}")]
  public async Task<ResponseDTO<List<ImagenesDTO>>> GetImagenClasificado(int id) {
    return await imagenes.GetImagenes(id);
  }

  [HttpPost]
  public async Task<ResponseDTO<List<ImagenesDTO>>> SaveData([FromForm] int id) {
    var files = Request.Form.Files;
    List<ImagenesDTO> data = [];
    foreach (var file in files) {
      byte[] bytes = imagenes.GetBytes(file);
      ImagenesDTO img = new() {
        Id = 0,
        Mime = file.ContentType,
        ClasificadoId = id,
        Imagen = bytes
      };
      data.Add(img);
    }
    return await imagenes.Post(data);
  }

  [HttpDelete("{id}")]
  public async Task<ResponseDTO<bool>> Delete(int id) {
    return await imagenes.Delete(id);
  }
}
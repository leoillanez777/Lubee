using AutoMapper;
using Lubee.Models;
using Lubee.Models.DTOs;
using NetTopologySuite.Geometries;

namespace Lubee.Middlewares;

public class AutoMapperProfile : Profile {
  public AutoMapperProfile() {
    CreateMap<TipoPropiedad, TipoDTO>().ReverseMap();
    CreateMap<TipoOperacion, TipoDTO>().ReverseMap();
    CreateMap<Clasificado, ClasificadoDTO>()
      .ForMember(d => d.Imagenes, o => o.MapFrom(src => MapImagenes(src.ClasificadoImagen)))
      .ForMember(d => d.Ubicacion, o => o.MapFrom(src => new Address { 
        Direccion = src.Direccion,
        Latitud = src.Ubicacion!.X,
        Longitud = src.Ubicacion!.Y
      }));
    
    CreateMap<ClasificadoDTO, Clasificado>()
      .ForMember(d => d.Ubicacion, o => o.MapFrom(src => MapPoint(src.Ubicacion)))
      .ForMember(d => d.Direccion, o => o.MapFrom(src => src.Ubicacion == null ? "" : src.Ubicacion.Direccion));

    CreateMap<ClasificadoImagen, ImagenesDTO>();
    CreateMap<ImagenesDTO, ClasificadoImagen>();
  }

  private static Point? MapPoint(Address? address) {
    if (address == null) return null;
    
    var point = new Point(address.Latitud, address.Longitud) { SRID = 4326 };
    return point;
  }

  private static List<ImagenesDTO>? MapImagenes(ICollection<ClasificadoImagen> clasificadoImagenes) {
    var map = new List<ImagenesDTO>();
    foreach (var img in clasificadoImagenes) {
      var m = new ImagenesDTO {
        Id = img.Id,
        ClasificadoId = img.ClasificadoId,
        Imagen = img.Imagen
      };
      map.Add(m);
    }
    return map;
  }
}
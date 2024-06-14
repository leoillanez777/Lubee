namespace Lubee.Models.DTOs;

public class ResponseDTO<T> {
  public bool Success { get; set; }
  public string Message { get; set; } = null!;
  public T? Result { get; set; }
}
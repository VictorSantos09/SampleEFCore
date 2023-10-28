namespace Sample.Core.Dtos;
public class BaseDto
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public dynamic? Data { get; set; }

    public BaseDto(string message, bool success, dynamic? data)
    {
        Message = message;
        Success = success;
        Data = data;
    }

    public static BaseDto Build(string message, bool success, dynamic? data = null)
    {
        return new BaseDto(message, success, data);
    }

    public static Task<BaseDto> ToTask(BaseDto dto)
    {
        return Task.FromResult(dto);
    }
}
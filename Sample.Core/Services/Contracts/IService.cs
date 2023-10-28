using Sample.Core.Dtos;

namespace Sample.Core.Services.Contracts;
public interface IService<T>
{
    Task<BaseDto> CreateAsync(T model);
    Task<BaseDto> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<BaseDto> UpdateAsync(int modelId, T model);
}
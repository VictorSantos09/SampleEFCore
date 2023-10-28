using Sample.Core.Models;

namespace Sample.Core.Services.Contracts;
internal interface IGenreService : IService<GenreModel>
{
    public Task<GenreModel> GetByNameAsync(string name);
}

using Sample.Core.Dtos;
using Sample.Core.Models;

namespace Sample.Core.Services.Contracts;
public interface IPeopleMoviesService
{
    Task<IEnumerable<PeopleMoviesModel>> GetAllAsync();
    Task<PeopleMoviesModel?> GetByIdAsync(int id);
    Task<BaseDto> UpdateAsync(int id, PeopleMovieDto peopleMovieDto);
    Task<BaseDto> WatchMovieAsync(int personId, int movieId);
}
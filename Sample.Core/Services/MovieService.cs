using Microsoft.EntityFrameworkCore;
using Sample.Core.Data;
using Sample.Core.Dtos;
using Sample.Core.Models;
using Sample.Core.Services.Contracts;

namespace Sample.Core.Services;

public class MovieService : IService<MovieModel>
{
    private readonly SampleContext _context;

    public MovieService(SampleContext context)
    {
        _context = context;
    }

    public async Task<BaseDto> CreateAsync(MovieModel movie)
    {
        _ = await _context.Movies.AddAsync(movie);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build($"Filme {movie.Title} cadastrado", true, null);
    }

    public async Task<BaseDto> UpdateAsync(MovieModel movieUpdated)
    {
        MovieModel? movieFound = await _context.Movies.FindAsync(movieUpdated.Id);
        if (movieFound is not null)
        {
            movieFound.Title = movieUpdated.Title;
            movieFound.Description = movieUpdated.Description;
            movieFound.GenreId = movieUpdated.GenreId;
            movieFound.Genre = movieUpdated.Genre;

            _ = _context.Update(movieFound);
            _ = await _context.SaveChangesAsync();
            return BaseDto.Build("pessoa atualizada", true);
        }
        return BaseDto.Build("pessoa não encontrada", false);
    }

    public async Task<BaseDto> DeleteAsync(int id)
    {
        MovieModel? movieFound = await _context.FindAsync<MovieModel>(id);
        if (movieFound is null)
            return BaseDto.Build("filme não encontrado", false);

        _ = _context.Remove(movieFound);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("filme removido", true);
    }

    public async Task<MovieModel?> GetByIdAsync(int id)
    {
        MovieModel? movieFound = await _context.FindAsync<MovieModel>(id);
        return movieFound;
    }

    public async Task<IEnumerable<MovieModel>> GetAllAsync()
    {
        List<MovieModel> movieFound = await _context.Movies.Include(m => m.Genre).ToListAsync();
        return movieFound;
    }
}
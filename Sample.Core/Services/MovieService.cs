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
        await _context.AddAsync(movie);
        await _context.SaveChangesAsync();
        return BaseDto.Build($"Filme {movie.Title} cadastrado", true, null);
    }

    public async Task<BaseDto> UpdateAsync(int modelId, MovieModel newMovie)
    {
        MovieModel? movie = await _context.Movies.FindAsync(modelId);
        if (movie is not null)
        {
            movie.Title = newMovie.Title;
            movie.Description = newMovie.Description;
            movie.GenreId = newMovie.GenreId;
            movie.Genre = newMovie.Genre;
            _ = _context.Update(movie);
            _ = await _context.SaveChangesAsync();
            return BaseDto.Build("pessoa atualizada", true);
        }
        return BaseDto.Build("pessoa não encontrada", false);
    }

    public async Task<BaseDto> DeleteAsync(int id)
    {
        MovieModel? movie = await _context.FindAsync<MovieModel>(id);
        if (movie is null)
            return BaseDto.Build("filme não encontrado", false);

        _context.Remove(movie);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("filme removido", true);
    }

    public async Task<MovieModel?> GetByIdAsync(int id)
    {
        return await _context.FindAsync<MovieModel>(id);
    }

    public async Task<IEnumerable<MovieModel>> GetAllAsync()
    {
        return await _context.Movies.Include(m => m.Genre).ToListAsync();
    }
}
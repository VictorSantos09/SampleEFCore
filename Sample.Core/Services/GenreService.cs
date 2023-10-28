using Microsoft.EntityFrameworkCore;
using Sample.Core.Data;
using Sample.Core.Dtos;
using Sample.Core.Models;
using Sample.Core.Services.Contracts;

namespace Sample.Core.Services;
public class GenreService : IGenreService
{
    private readonly SampleContext _context;

    public GenreService(SampleContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GenreModel>> GetAllAsync()
    {
        List<GenreModel> output = await _context.Genres.ToListAsync();
        return output;
    }

    public async Task<GenreModel?> GetByIdAsync(int id)
    {
        GenreModel? genreFound = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        return genreFound;
    }

    public async Task<GenreModel?> GetByNameAsync(string name)
    {
        GenreModel? genreFound = await _context.Genres.FirstOrDefaultAsync(x => x.Name == name);
        return genreFound;
    }

    public async Task<BaseDto> CreateAsync(GenreModel genre)
    {
        _ = await _context.AddAsync(genre);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("criado com sucesso", true);
    }

    public async Task<BaseDto> UpdateAsync(GenreModel genreUpdated)
    {
        GenreModel? genreFound = await GetByIdAsync(genreUpdated.Id);
        
        if(genreFound is not null)
        {
            genreFound.Name = genreUpdated.Name;
            _ = _context.Update(genreFound);
            _ = await _context.SaveChangesAsync();
            return BaseDto.Build("atualizado com sucesso", true);
        }

        return BaseDto.Build("gênero não encontrado", true);
    }

    public async Task<BaseDto> DeleteAsync(int id)
    {
        GenreModel? genreFound = await GetByIdAsync(id);
        
        if (genreFound is null)
        {
            return BaseDto.Build("gênero não encontrado", false);
        }

        _ = _context.Remove(genreFound);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("deletado com sucesso", true);
    }
}

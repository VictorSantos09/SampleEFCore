using Microsoft.EntityFrameworkCore;
using Sample.Core.Data;
using Sample.Core.Dtos;
using Sample.Core.Models;
using Sample.Core.Services.Contracts;

namespace Sample.Core.Services;
public class GenreService : IService<GenreModel>
{
    private readonly SampleContext _context;

    public GenreService(SampleContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GenreModel>> GetAllAsync()
    {
        List<GenreModel> result = await _context.Genres.ToListAsync();
        return result;
    }

    public async Task<GenreModel?> GetByIdAsync(int id)
    {
        return await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<GenreModel?> GetByNameAsync(string name)
    {
        return await _context.Genres.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<BaseDto> CreateAsync(GenreModel genre)
    {
        _ = await _context.Genres.AddAsync(genre);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("criado com sucesso", true);
    }

    public async Task<BaseDto> UpdateAsync(int modelId, GenreModel newGenre)
    {
        GenreModel? genreModel = await GetByIdAsync(modelId);
        if(genreModel is not null)
        {
            genreModel.Name = newGenre.Name;
            _ = _context.Genres.Update(genreModel);
            _ = await _context.SaveChangesAsync();
            return BaseDto.Build("atualizado com sucesso", true);
        }
        return BaseDto.Build("gênero não encontrado", true);
    }

    public async Task<BaseDto> DeleteAsync(int id)
    {
        GenreModel? genre = await GetByIdAsync(id);
        if (genre is null)
        {
            return BaseDto.Build("gênero não encontrado", false);
        }
        _ = _context.Genres.Remove(genre);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("deletado com sucesso", true);
    }
}

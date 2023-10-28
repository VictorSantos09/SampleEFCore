using Microsoft.EntityFrameworkCore;
using Sample.Core.Data;
using Sample.Core.Dtos;
using Sample.Core.Models;
using Sample.Core.Services.Contracts;

namespace Sample.Core.Services;
public class PersonService : IService<PersonModel>
{
    private readonly SampleContext _context;

    public PersonService(SampleContext context)
    {
        _context = context;
    }

    public async Task<BaseDto> CreateAsync(PersonModel person)
    {
        if (person is null)
        {
            return BaseDto.Build("pessoa não pode ser nula", false);
        }

        _ = await _context.AddAsync(person);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("pessoa adicionada", true);
    }

    public async Task<BaseDto> UpdateAsync(PersonModel personUpdated)
    {
        PersonModel? personFound = await _context.People.FindAsync(personUpdated.Id);
        if (personFound is not null)
        {
            personFound.FirstName = personUpdated.FirstName;
            personFound.LastName = personUpdated.LastName;
            
            _ = _context.Update(personFound);
            _ = _context.SaveChanges();
            return BaseDto.Build("pessoa atualizada", true);
        }
        return BaseDto.Build("pessoa não encontrada", false);
    }

    public async Task<BaseDto> DeleteAsync(int id)
    {
        PersonModel? personFound = await GetByIdAsync(id);
        if (personFound is null)
            return BaseDto.Build("pessoa não encontrada", false);

        _ = _context.Remove(personFound);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("pessoa removida", false);
    }

    public async Task<PersonModel?> GetByIdAsync(int id)
    {
        var personFound = await _context.People.FindAsync(id);
        return personFound;
    }

    public async Task<IEnumerable<PersonModel>> GetAllAsync()
    {
        var peopleFound = await _context.People.ToListAsync();
        return peopleFound;
    }
}
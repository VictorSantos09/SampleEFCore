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

    public async Task<BaseDto> UpdateAsync(int personId, PersonModel newPerson)
    {
        PersonModel? person = await _context.People.FindAsync(personId);
        if (person is not null)
        {
            person.FirstName = newPerson.FirstName;
            person.LastName = newPerson.LastName;
            _ = _context.Update(person);
            _ = _context.SaveChanges();
            return BaseDto.Build("pessoa atualizada", true);
        }
        return BaseDto.Build("pessoa não encontrada", false);
    }

    public async Task<BaseDto> DeleteAsync(int id)
    {
        PersonModel? person = await GetByIdAsync(id);
        if (person is null)
            return BaseDto.Build("pessoa não encontrada", false);

        _ = _context.Remove(person);
        _ = await _context.SaveChangesAsync();
        return BaseDto.Build("pessoa removida", false);
    }

    public async Task<PersonModel?> GetByIdAsync(int id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task<IEnumerable<PersonModel>> GetAllAsync()
    {
        var result = await _context.People.ToListAsync();
        return result;
    }
}
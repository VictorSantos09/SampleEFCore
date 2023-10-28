using Microsoft.EntityFrameworkCore;
using Sample.Core.Data;
using Sample.Core.Dtos;
using Sample.Core.Models;
using Sample.Core.Services.Contracts;

namespace Sample.Core.Services;

public class PeopleMoviesService
{
    private readonly SampleContext _context;
    private readonly IService<PersonModel> _personService;
    private readonly IService<MovieModel> _movieService;

    public PeopleMoviesService(SampleContext context,
        IService<PersonModel> personService,
        IService<MovieModel> movieService)
    {
        _context = context;
        _personService = personService;
        _movieService = movieService;
    }

    public Task<IEnumerable<PeopleMoviesModel>> GetAllAsync()
    {
        return Task.FromResult(_context.PeopleMovies
            .Include(x => x.Movie)
            .ThenInclude(x => x.Genre)
            .Include(x => x.Person)
            .AsEnumerable());
    }

    public Task<PeopleMoviesModel?> GetByIdAsync(int id)
    {
        return Task.FromResult(_context.PeopleMovies
            .Include(x => x.Movie)
            .ThenInclude(x => x.Genre)
            .Include(x => x.Person)
            .FirstOrDefault(x => x.Id == id));
    }

    public async Task<BaseDto> UpdateAsync(int id, PeopleMovieDto peopleMovieDto)
    {
        PeopleMoviesModel? peopleMovie = await GetByIdAsync(id);
        if (peopleMovie is not null)
        {
            peopleMovie.PersonId = peopleMovieDto.PersonId;
            peopleMovie.MovieId = peopleMovieDto.MovieId;
            _ = _context.Update(peopleMovie);
            _ = _context.SaveChanges();
            return BaseDto.Build("pessoa atualizada", true);
        }
        return BaseDto.Build("pessoa não encontrada", false);
    }

    public async Task<BaseDto> WatchMovieAsync(int personId, int movieId)
    {
        var existsPerson = _context.People.Contains(new PersonModel { Id = personId });
        var existsMovie = _context.Movies.Contains(new MovieModel { Id = movieId });

        if (existsPerson is false)
            return BaseDto.Build("pessoa não encontrada", false);

        if (existsMovie is false)
            return BaseDto.Build("filme não encontrado", false);

        PeopleMoviesModel peopleMovies = new()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            PersonId = personId,
            MovieId = movieId
        };

        _ = await _context.AddAsync(peopleMovies);
        _ = _context.SaveChanges();
        return BaseDto.Build("salvo com sucesso", true);
    }
}
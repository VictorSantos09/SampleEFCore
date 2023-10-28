namespace Sample.Core.Models;

public class PeopleMoviesModel
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int MovieId { get; set; }
    public PersonModel Person { get; set; }
    public MovieModel Movie { get; set; }
    public DateOnly Date { get; set; }

    public PeopleMoviesModel(PersonModel person, MovieModel movie, DateOnly date)
    {
        PersonId = person.Id;
        MovieId = movie.Id;
        Person = person;
        Movie = movie;
        Date = date;
    }

    public PeopleMoviesModel()
    {

    }
}

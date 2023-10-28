namespace Sample.Core.Models;

public class MovieModel
{
    public int Id { get; set; }
    public int GenreId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public GenreModel Genre { get; set; }

    public MovieModel(string title, string description, GenreModel genre, int genreId)
    {
        Title = title;
        Description = description;
        Genre = genre;
        GenreId = genreId;
    }

    public MovieModel()
    {

    }
}

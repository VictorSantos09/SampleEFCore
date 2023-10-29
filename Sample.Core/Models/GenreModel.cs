using Sample.Core.Models.Contracts;

namespace Sample.Core.Models;
public class GenreModel : IModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public GenreModel(int id)
    {
        Id = id;
    }

    public GenreModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public GenreModel()
    {

    }
}

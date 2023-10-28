using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Core.Models;

public class PersonModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [NotMapped]
    public string FullName
    {
        get => $"{FirstName} {LastName}";
        set => FullName = $"{FirstName} {LastName}";
    }

    public PersonModel(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public PersonModel()
    {

    }
}

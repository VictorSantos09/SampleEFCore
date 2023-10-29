namespace Sample.Core.Validators;
public class PersonValidator
{
    public const int MaxCharactersAllowedFirstName = 45;
    public const int MaxCharactersAllowedLastName = 45;

    public static IEnumerable<string> MaxDigitsFirstName(string input)
    {
        if (string.IsNullOrEmpty(input) == false && MaxCharactersAllowedFirstName < input?.Length)
            yield return $"Máximo de {MaxCharactersAllowedFirstName} caracteres";
    }

    public static IEnumerable<string> MaxDigitsLastName(string input)
    {
        if (string.IsNullOrEmpty(input) == false && MaxCharactersAllowedLastName < input?.Length)
            yield return $"Máximo de {MaxCharactersAllowedLastName} caracteres";
    }
}

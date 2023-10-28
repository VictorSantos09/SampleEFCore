namespace Sample.Core.Validators;
public class PersonValidator
{
    public const int MaxCharactersAllowedFirstName = 45;
    public const int MaxCharactersAllowedLastName = 45;

    public static IEnumerable<string> MaxDigitsFirstName(string ch)
    {
        if (string.IsNullOrEmpty(ch) == false && MaxCharactersAllowedFirstName < ch?.Length)
            yield return $"Máximo de {MaxCharactersAllowedFirstName} caracteres";
    }

    public static IEnumerable<string> MaxDigitsLastName(string ch)
    {
        if (string.IsNullOrEmpty(ch) == false && MaxCharactersAllowedLastName < ch?.Length)
            yield return $"Máximo de {MaxCharactersAllowedLastName} caracteres";
    }
}

namespace Sample.Core.Validators;
public class MovieValidator
{
    public const int MaxCharactersAllowedTitle = 45;
    public const int MaxCharactersAllowedDescription = 200;

    public static IEnumerable<string> MaxDigitsTitle(string input)
    {
        if (string.IsNullOrEmpty(input) == false && MaxCharactersAllowedTitle < input?.Length)
            yield return $"Máximo de {MaxCharactersAllowedTitle} caracteres";
    }

    public static IEnumerable<string> MaxDigitsDescription(string input)
    {
        if (string.IsNullOrEmpty(input) == false && MaxCharactersAllowedDescription < input?.Length)
            yield return $"Máximo de {MaxCharactersAllowedDescription} caracteres";
    }
}

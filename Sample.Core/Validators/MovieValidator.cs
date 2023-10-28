namespace Sample.Core.Validators;
public class MovieValidator
{
    public const int MaxCharactersAllowedTitle = 45;
    public const int MaxCharactersAllowedDescription = 200;

    public static IEnumerable<string> MaxDigitsTitle(string ch)
    {
        if (string.IsNullOrEmpty(ch) == false && MaxCharactersAllowedTitle < ch?.Length)
            yield return $"Máximo de {MaxCharactersAllowedTitle} caracteres";
    }

    public static IEnumerable<string> MaxDigitsDescription(string ch)
    {
        if (string.IsNullOrEmpty(ch) == false && MaxCharactersAllowedDescription < ch?.Length)
            yield return $"Máximo de {MaxCharactersAllowedDescription} caracteres";
    }
}

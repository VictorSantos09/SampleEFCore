namespace Sample.Core.Validators;
public class GenreValidator
{
    public const int MaxCharactersAllowedName = 45;
    public static IEnumerable<string> MaxDigitsName(string input)
    {
        if (string.IsNullOrEmpty(input) == false && MaxCharactersAllowedName < input?.Length)
            yield return $"Máximo de {MaxCharactersAllowedName} caracteres";
    }
}
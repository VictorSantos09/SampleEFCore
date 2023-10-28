namespace Sample.Core.Validators;
public class GenreValidator
{
    public const int MaxCharactersAllowedName = 45;
    public static IEnumerable<string> MaxDigitsName(string ch)
    {
        if (string.IsNullOrEmpty(ch) == false && MaxCharactersAllowedName < ch?.Length)
            yield return $"Máximo de {MaxCharactersAllowedName} caracteres";
    }
}
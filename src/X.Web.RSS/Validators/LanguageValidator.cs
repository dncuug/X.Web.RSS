using System.Globalization;

namespace X.Web.RSS.Validators;

public class LanguageValidator : IValidator<string?>
{
    public void Validate(string? value)
    {
        if (value != null)
        {
            new CultureInfo(value);
        }
    }
}
using System;

namespace X.Web.RSS.Validators;

public class UriValidator
{
    public void Validate(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            try
            {
                var url = new Uri(value, UriKind.Absolute);
            }
            catch (Exception ex)
            {
                throw new UriFormatException($"Invalid url string: {value}", ex);
            }
        }
    }
}
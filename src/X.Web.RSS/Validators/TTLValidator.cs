using System;

namespace X.Web.RSS.Validators;

public class TTLValidator
{
    public void Validate(int? value)
    {
        if (value.HasValue && (value < 0 || value > 999999))
        {
            throw new ArgumentException("TTL must be between 0 and 999999");
        }
    }
}
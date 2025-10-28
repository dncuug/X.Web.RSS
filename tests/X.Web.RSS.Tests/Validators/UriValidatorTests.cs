using System;
using X.Web.RSS.Validators;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class UriValidatorTests
{
    [Fact]
    public void Validate_NullOrEmpty_DoesNotThrow()
    {
        var v = new UriValidator();
        v.Validate(null);
        v.Validate(string.Empty);
    }

    [Fact]
    public void Validate_InvalidUri_ThrowsUriFormatException()
    {
        var v = new UriValidator();
        UriFormatException e = null;
        try
        {
            v.Validate("not a uri");
        }
        catch (UriFormatException ex)
        {
            e = ex;
        }

        Assert.NotNull(e);
    }

    [Fact]
    public void Validate_ValidAbsoluteUri_DoesNotThrow()
    {
        var v = new UriValidator();
        v.Validate("http://example.com/path");
    }
}


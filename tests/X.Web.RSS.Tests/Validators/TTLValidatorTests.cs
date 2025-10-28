using System;
using X.Web.RSS.Validators;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class TTLValidatorTests
{
    [Fact]
    public void Validate_Null_DoesNotThrow()
    {
        var v = new TTLValidator();
        v.Validate(null);
    }

    [Fact]
    public void Validate_Negative_ThrowsArgumentException()
    {
        var v = new TTLValidator();
        ArgumentException e = null;
        try
        {
            v.Validate(-1);
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        Assert.NotNull(e);
    }

    [Fact]
    public void Validate_TooLarge_ThrowsArgumentException()
    {
        var v = new TTLValidator();
        ArgumentException e = null;
        try
        {
            v.Validate(1000000);
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        Assert.NotNull(e);
    }

    [Fact]
    public void Validate_Valid_DoesNotThrow()
    {
        var v = new TTLValidator();
        v.Validate(0);
        v.Validate(10);
        v.Validate(999999);
    }
}

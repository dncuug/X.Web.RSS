using System;
using X.Web.RSS.Structure;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class RssTtlTest
{
    [Fact]
    public void Ctor_ValidTtlParameter_Ok()
    {
        // Arrange
        const int TTL = 10;

        // Action
        RssTtl rssTtl = new RssTtl(TTL);

        // Assert
        Assert.Equal(TTL, rssTtl.TTL);
    }

    [Fact]
    public void Ctor_TtlLessZero_Error()
    {
        // Arrange
        const int TTL = -1;

        // Action
        ArgumentException e = null;
        try
        {
            new RssTtl(TTL);
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void SetTtl_ValidTtlParameter_Ok()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();
        const int TTL = 10;

        // Action
        rssTtl.TTL = TTL;

        // Assert
        Assert.Equal(TTL, rssTtl.TTL);
    }

    [Fact]
    public void SetTtl_TtlLessZero_Error()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();
        const int TTL = -1;

        // Action
        ArgumentException e = null;
        try
        {
            rssTtl.TTL = TTL;
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }


    [Fact]
    public void SetString_StringLessZero_Error()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();

        // Action
        ArgumentException e = null;
        try
        {
            rssTtl.TTL = -1;
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void SetTtl_ConvertToString_String()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();
        const int TTL = 10;

        // Action
        rssTtl.TTL = 10;

        // Assert
        Assert.Equal(TTL, rssTtl.TTL);
    }

    [Fact]
    public void SetString_ConvertToTtl_Ttl()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();
        const int TTL = 10;

        // Action
        rssTtl.TTL = TTL;

        // Assert
        Assert.Equal(TTL.ToString(), rssTtl.TTL.ToString());
    }

    [Fact]
    public void SetTtl_Zero_StringNull()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();

        // Action
        rssTtl.TTL = 0;

        // Assert
        Assert.Null(rssTtl.TTL);
    }
}
using System;
using X.Web.RSS.Structure;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class RssTtlTest
{
    [Fact]
    public void Constructor_WithValidTtl_SetsValue()
    {
        // Arrange
        const int TTL = 10;

        // Action
        RssTtl rssTtl = new RssTtl(TTL);

        // Assert
        Assert.Equal(TTL, rssTtl.TTL);
    }

    [Fact]
    public void Constructor_WithNegativeTtl_ThrowsArgumentException()
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
    public void Setter_WithValidTtl_SetsValue()
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
    public void Setter_WithNegativeTtl_ThrowsArgumentException()
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
    public void Setter_InvalidNegative_ThrowsArgumentException()
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
    public void Setter_WithValidTtl_PreservesValue()
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
    public void Setter_WithValidTtl_AsStringMatches()
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
    public void SettingZero_TtlBecomesNull()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();

        // Action
        rssTtl.TTL = 0;

        // Assert
        Assert.Null(rssTtl.TTL);
    }

    [Fact]
    public void SettingTooLarge_TtlThrowsArgumentException()
    {
        // Arrange
        RssTtl rssTtl = new RssTtl();

        // Action
        ArgumentException e = null;
        try
        {
            rssTtl.TTL = 1000000; // greater than allowed 999999
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }
}
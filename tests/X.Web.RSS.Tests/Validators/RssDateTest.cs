using Xunit;
using System;
using X.Web.RSS.Extensions;
using X.Web.RSS.Structure;

namespace X.Web.RSS.Tests.Validators;

public class RssDateTest
{
    [Fact]
    public void Constructor_WithDate_SetsDate()
    {
        // Arrange
        DateTime date = DateTime.Now.Date;

        // Action
        RssDate rssDate = new RssDate(date);

        // Assert
        Assert.Equal(date, rssDate.Date);
    }

    [Fact]
    public void Constructor_WithFutureDate_ThrowsArgumentException()
    {
        // Arrange
        DateTime date = DateTime.Now.AddDays(1);

        // Action
        ArgumentException e = null;

        try
        {
            new RssDate(date);
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void Setter_WithDate_SetsDate()
    {
        // Arrange
        RssDate rssDate = new RssDate();
        DateTime date = DateTime.Now;

        // Action
        rssDate.Date = date;

        // Assert
        Assert.Equal(date, rssDate.Date);
    }

    [Fact]
    public void Setter_WithFutureDate_ThrowsArgumentException()
    {
        // Arrange
        RssDate rssDate = new RssDate();
        DateTime date = DateTime.Now.AddDays(1);

        // Action
        ArgumentException e = null;
        try
        {
            rssDate.Date = date;
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void Constructor_WithDateString_SetsDateString()
    {
        // Arrange
        String date = DateTime.Now.Date.ToString();

        // Action
        RssDate rssDate = new RssDate(date);

        // Assert
        Assert.Equal(date, rssDate.DateString);
    }

    [Fact]
    public void Constructor_WithFutureDateString_ThrowsArgumentException()
    {
        // Arrange
        String date = DateTime.Now.AddDays(1).ToString("R");

        // Action
        ArgumentException e = null;
        try
        {
            new RssDate(date);
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void Setter_WithDateString_SetsDateString()
    {
        // Arrange
        RssDate rssDate = new RssDate();
        String date = DateTime.Now.Date.ToString();

        // Action
        rssDate.DateString = date;

        // Assert
        Assert.Equal(date, rssDate.DateString);
    }

    [Fact]
    public void Setter_WithFutureDateString_ThrowsArgumentException()
    {
        // Arrange
        RssDate rssDate = new RssDate();
        String date = DateTime.Now.AddDays(1).ToString("R");

        // Action
        ArgumentException e = null;
        try
        {
            rssDate.DateString = date;
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void SettingDateString_ParsesToDate()
    {
        DateTime date = DateTime.Now.Date;

        RssDate rssDate = new RssDate();
        rssDate.DateString = date.ToString();

        // Assert
        Assert.Equal(date, rssDate.Date);
    }

    [Fact]
    public void SettingDate_FormatsToString()
    {
        // Arrange
        RssDate rssDate = new RssDate();
        DateTime date = DateTime.Now;

        // Action
        rssDate.Date = date;

        // Assert
        Assert.Equal(date.ToString(), rssDate.DateString);
    }

    [Fact]
    public void SettingNullDateString_ClearsDate()
    {
        // Arrange
        RssDate rssDate = new RssDate();

        // Action
        rssDate.DateString = null;

        // Assert
        Assert.Null(rssDate.Date);
    }

    [Fact]
    public void SettingNullDate_ClearsDateString()
    {
        // Arrange
        RssDate rssDate = new RssDate();

        // Action
        rssDate.Date = null;

        // Assert
        Assert.True(String.IsNullOrEmpty(rssDate.DateString));
    }

    [Fact]
    public void SettingInvalidDateString_ThrowsArgumentException()
    {
        // Arrange
        RssDate rssDate = new RssDate();
        const string InvalidDate = "adsfsadf";

        // Action
        ArgumentException e = null;
        try
        {
            rssDate.DateString = InvalidDate;
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void Constructor_WithInvalidDateString_ThrowsArgumentException()
    {
        // Arrange
        const string InvalidDate = "adsfsadf";

        // Action
        ArgumentException e = null;
        try
        {
            new RssDate(InvalidDate);
        }
        catch (ArgumentException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void DateExtension_ToAndFromRFC822_PreservesDate()
    {
        var date = DateTime.Now;

        var rfcDateInString = date.ToRFC822Date();
        var parsedDate = rfcDateInString.FromRFC822Date();

        Assert.Equal(date.ToLongDateString(), parsedDate.ToLongDateString());
        Assert.Equal(date.ToLongTimeString(), parsedDate.ToLongTimeString());
    }

    [Fact]
    public void DateStringISO8601_ReturnsIso8601WhenDateSet()
    {
        var date = new DateTime(2020, 1, 2, 3, 4, 5);
        var rssDate = new RssDate(date);

        var iso = rssDate.DateStringISO8601;

        Assert.Contains("2020-01-02T03:04:05", iso);
    }
}